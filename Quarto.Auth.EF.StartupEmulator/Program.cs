﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Quarto.Auth.EF.StartupEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext>
        {
            private const string migrationOptionsFileName = "MigrationOptions.json";
            /// <summary>
            /// Method to create MigrationOptions.json file (if not created) 
            /// that should contain the connection string for Quarto.Auth.Master
            /// </summary>
            /// <param name="args"></param>
            /// <returns></returns>
            public AuthContext CreateDbContext(string[] args)
            {
                while (!File.Exists(migrationOptionsFileName))
                {
                    Console.WriteLine("Please type in a connection string to your Quarto.Master Database:");

                    string inputString = Console.ReadLine();

                    File.WriteAllText(migrationOptionsFileName,
                        $@"{{
  ""ConnectionStrings"": {{
    ""Master"": ""{inputString.Replace("\\", "\\\\").Replace("\"", "\\\"")}""
  }}
}}");
                }

                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile(migrationOptionsFileName);

                IConfigurationRoot configRoot = configurationBuilder.Build();

                args = new string[] { configRoot.GetConnectionString("Master") };

                if (args == null || args.Length < 1)
                    throw new ArgumentNullException(nameof(args)
                        , "No arguments passed, the first argument must be the connectionString for the database");

                string connectionString = args[0];
                var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
                Console.WriteLine($"Using connection string: {connectionString}");
                optionsBuilder.UseSqlServer(connectionString);

                return new AuthContext(optionsBuilder.Options);
            }
        }
    }
}
