﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quarto.Api.EF;

namespace Quarto.Api.EF.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20200728103204_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quarto.Api.Models.EnumListingAccommodationType", b =>
                {
                    b.Property<byte>("ID")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("enum.Listing.AccommodationType");
                });

            modelBuilder.Entity("Quarto.Api.Models.EnumListingAvailabilityType", b =>
                {
                    b.Property<byte>("ID")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.ToTable("enum.Listing.AvailabilityType");
                });

            modelBuilder.Entity("Quarto.Api.Models.Listing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AccomodationTypeID")
                        .HasColumnType("tinyint");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("AvailabilityTypeID")
                        .HasColumnType("tinyint");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentListing")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AccomodationTypeID")
                        .IsUnique();

                    b.HasIndex("AvailabilityTypeID")
                        .IsUnique();

                    b.ToTable("Listing.Data");
                });

            modelBuilder.Entity("Quarto.Api.Models.Listing", b =>
                {
                    b.HasOne("Quarto.Api.Models.EnumListingAccommodationType", "EnumListingAccommodationType")
                        .WithOne("Listing")
                        .HasForeignKey("Quarto.Api.Models.Listing", "AccomodationTypeID")
                        .HasConstraintName("FK__Listing.Data__enum.Listing.AccommodationType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quarto.Api.Models.EnumListingAvailabilityType", "EnumListingAvailabilityType")
                        .WithOne("Listing")
                        .HasForeignKey("Quarto.Api.Models.Listing", "AvailabilityTypeID")
                        .HasConstraintName("FK__Listing.Data__enum.Listing.AvailabilityType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
