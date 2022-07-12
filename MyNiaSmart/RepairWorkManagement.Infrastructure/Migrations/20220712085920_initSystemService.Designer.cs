﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairWorkShopManagement.Infrastructure.EFCore;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(RepairWorkShopContext))]
    [Migration("20220712085920_initSystemService")]
    partial class initSystemService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepairWorkShopManagement.Domain.SystemServiceAgg.SystemService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BaseFeePrice")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EngTitle")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FarsiTitle")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long>("ProductBrandId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductUsageTypeId")
                        .HasColumnType("bigint");

                    b.Property<int>("SystemSharePercent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SystemServices");
                });
#pragma warning restore 612, 618
        }
    }
}
