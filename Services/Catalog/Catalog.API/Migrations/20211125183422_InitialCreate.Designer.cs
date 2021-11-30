﻿// <auto-generated />
using System;
using Catalog.API.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Catalog.API.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20211125183422_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Catalog.API.Entities.CatalogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CatalogItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Description = "ANGULAR T-Shirt",
                            ImgUrl = "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/unisex-premium-t-shirt-true-royal-front-601befd7623e4_360x.jpg?v=1612443619",
                            Name = "ANGULAR T-Shirt",
                            Price = 25m
                        },
                        new
                        {
                            Id = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Description = "VUE T-Shirt",
                            ImgUrl = "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/unisex-premium-t-shirt-navy-front-601bf2c110bb9_1800x1800.jpg?v=1612444364",
                            Name = "VUE T-Shirt",
                            Price = 25m
                        },
                        new
                        {
                            Id = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            Description = "JAVASCRIPT Mug with Color Inside",
                            ImgUrl = "https://cdn.shopify.com/s/files/1/0528/4148/0360/products/white-ceramic-mug-with-color-inside-yellow-11oz-left-602ed2f551170_1800x1800.jpg?v=1613681400",
                            Name = "JAVASCRIPT Mug with Color Inside",
                            Price = 16m
                        });
                });

            modelBuilder.Entity("Catalog.API.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            Name = "T-Shirt"
                        },
                        new
                        {
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            Name = "Mug"
                        },
                        new
                        {
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            Name = "Accessories"
                        });
                });

            modelBuilder.Entity("Catalog.API.Entities.CatalogItem", b =>
                {
                    b.HasOne("Catalog.API.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}