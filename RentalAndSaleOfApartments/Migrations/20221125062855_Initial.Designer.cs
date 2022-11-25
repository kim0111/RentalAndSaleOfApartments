﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalAndSaleOfApartments.Data;

#nullable disable

namespace RentalAndSaleOfApartments.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221125062855_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentalAndSaleOfApartments.Models.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnersPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedOnSite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalPeriodInMounth")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<string>("SizeInM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRenovation")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("RentalAndSaleOfApartments.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnersPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedOnSite")
                        .HasColumnType("datetime2");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<string>("SizeInM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRenovation")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
