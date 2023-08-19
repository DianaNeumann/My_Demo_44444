﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApp.DataAcess;

#nullable disable

namespace StockApp.DataAcess.Migrations
{
    [DbContext(typeof(MasterDbContext))]
    [Migration("20230819023611_Add_Boxes_And_Palletes")]
    partial class Add_Boxes_And_Palletes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("StockApp.DataAcess.Entities.Box", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateOfManufacture")
                        .HasColumnType("TEXT");

                    b.Property<double>("Depth")
                        .HasColumnType("REAL");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<double>("Width")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("StockApp.DataAcess.Entities.Pallete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Depth")
                        .HasColumnType("REAL");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<double>("Width")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Palletes");
                });
#pragma warning restore 612, 618
        }
    }
}
