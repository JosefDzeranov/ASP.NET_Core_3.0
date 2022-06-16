﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220616223440_TestImages")]
    partial class TestImages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.ComparingProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ComparingProducts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.DeliveryInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryInformarions");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.FavouriteProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("FavouriteProducts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            ImageId = new Guid("484c735f-2b49-47da-a864-16a7235453eb"),
                            ProductId = new Guid("484c735f-2b49-47da-a864-16a7235453ee"),
                            Url = "/images/products/king.jpg"
                        },
                        new
                        {
                            ImageId = new Guid("4b440c91-6c7d-4269-8654-5fe34b4089ab"),
                            ProductId = new Guid("4b440c91-6c7d-4269-8654-5fe34b4089ae"),
                            Url = "/images/products/terri.jpg"
                        },
                        new
                        {
                            ImageId = new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26b"),
                            ProductId = new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26c"),
                            Url = "/images/products/london.jpg"
                        },
                        new
                        {
                            ImageId = new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3b"),
                            ProductId = new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3e"),
                            Url = "/images/products/don.jpg"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DeliveryInformationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryInformationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("484c735f-2b49-47da-a864-16a7235453ee"),
                            Cost = 450m,
                            Description = "Автор: Стивен Кинг Жанр: мистика, ужасы",
                            Name = "Оно",
                            Pages = 1025
                        },
                        new
                        {
                            Id = new Guid("4b440c91-6c7d-4269-8654-5fe34b4089ae"),
                            Cost = 350m,
                            Description = "Автор: Терри Пратчетт Жанр: фэнтези",
                            Name = "Мрачный жнец",
                            Pages = 356
                        },
                        new
                        {
                            Id = new Guid("c6fe4bbe-d224-4b64-98fd-570fa48fa26c"),
                            Cost = 300m,
                            Description = "Автор: Джек Лондон Жанр: роман",
                            Name = "Странник по звездам",
                            Pages = 332
                        },
                        new
                        {
                            Id = new Guid("bebef8e9-20ef-4a84-8f48-6d5cbaecdf3e"),
                            Cost = 350m,
                            Description = "Автор: Дарья Донцова Жанр: детектив",
                            Name = "Крутые наследнички",
                            Pages = 425
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.ComparingProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.FavouriteProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.DeliveryInformation", "DeliveryInformation")
                        .WithMany()
                        .HasForeignKey("DeliveryInformationId");

                    b.Navigation("DeliveryInformation");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
