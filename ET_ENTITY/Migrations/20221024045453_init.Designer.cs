﻿// <auto-generated />
using System;
using ET_ENTITY;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ET_ENTITY.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20221024045453_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ET_ENTITY.EntityModels.DailyExpence", b =>
                {
                    b.Property<int>("ExpenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpenceDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("categoriesCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ExpenceId");

                    b.HasIndex("categoriesCategoryId");

                    b.ToTable("DailyExpences");
                });

            modelBuilder.Entity("ET_ENTITY.EntityModels.ExpCategories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("ExpCategories");
                });

            modelBuilder.Entity("ET_ENTITY.EntityModels.DailyExpence", b =>
                {
                    b.HasOne("ET_ENTITY.EntityModels.ExpCategories", "categories")
                        .WithMany("Expenses")
                        .HasForeignKey("categoriesCategoryId");

                    b.Navigation("categories");
                });

            modelBuilder.Entity("ET_ENTITY.EntityModels.ExpCategories", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
