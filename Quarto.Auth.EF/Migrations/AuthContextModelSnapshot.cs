﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quarto.Auth.EF;

namespace Quarto.Auth.EF.Migrations
{
    [DbContext(typeof(AuthContext))]
    partial class AuthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quarto.Auth.Models.EnumUserType", b =>
                {
                    b.Property<byte>("ID")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("enum.User.Type");
                });

            modelBuilder.Entity("Quarto.Auth.Models.LoggingData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ErrorType")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("Logging.Data");
                });

            modelBuilder.Entity("Quarto.Auth.Models.UserCred", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("AuthenticationHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUsedDT")
                        .HasColumnType("datetime2");

                    b.Property<byte>("UserType")
                        .HasColumnType("tinyint");

                    b.HasKey("UserID");

                    b.HasIndex("UserType")
                        .IsUnique();

                    b.ToTable("User.Cred");
                });

            modelBuilder.Entity("Quarto.Auth.Models.UserData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("PasswordChangeDT")
                        .HasColumnType("datetime2(0)");

                    b.Property<bool>("ResetPassword")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasName("IX_User.Data_EmailAddress")
                        .HasFilter("[EmailAddress] IS NOT NULL");

                    b.ToTable("User.Data");
                });

            modelBuilder.Entity("Quarto.Auth.Models.UserCred", b =>
                {
                    b.HasOne("Quarto.Auth.Models.UserData", "User")
                        .WithOne("UserCred")
                        .HasForeignKey("Quarto.Auth.Models.UserCred", "UserID")
                        .HasConstraintName("FK_User.Cred_User.Data")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quarto.Auth.Models.EnumUserType", "EnumUserType")
                        .WithOne("UserCred")
                        .HasForeignKey("Quarto.Auth.Models.UserCred", "UserType")
                        .HasConstraintName("FK_User.Cred_enum.User.Type")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
