﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

namespace OnlineShop.DB.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Entities.CartEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Entities.CartItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderEntityId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Entities.DeliveryInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdressToDelivery")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfClient")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeliveryInfoEntity");
                });

            modelBuilder.Entity("Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeliveryInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("TotalCostWithDiscount")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryInfoId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountInDb")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImgPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AmountInDb = 6,
                            Cost = 610m,
                            Description = "Ширина 135 см, Плотность от 239 г/м2, Состав: вискоза - 60%, лён - 30%, хлопок - 10%, Производитель - Китай",
                            ImgPath = "/img/linen_blue.jpg",
                            Name = "Лён однотонный, голубой"
                        },
                        new
                        {
                            Id = -2,
                            AmountInDb = 3,
                            Cost = 4200m,
                            Description = "Ширина 120 см, Состав: эластан, кашемир, Производитель - Италия",
                            ImgPath = "/img/cashemir_vi.jpg",
                            Name = "Кашемировый трикотаж, фиолетовый"
                        },
                        new
                        {
                            Id = -3,
                            AmountInDb = 8,
                            Cost = 2700m,
                            Description = "Ширина 135 см, Состав: шёлк - 100%, Производитель - Италия",
                            ImgPath = "/img/Silk_green.jpg",
                            Name = "Шёлк, бильярдный цвет"
                        },
                        new
                        {
                            Id = -4,
                            AmountInDb = 9,
                            Cost = 5700m,
                            Description = "Ширина 120 см, Состав: эластан, кашемир, Производитель - Италия",
                            ImgPath = "/img/cashemir_li.jpg",
                            Name = "Кашемир, лиловый"
                        });
                });

            modelBuilder.Entity("Entities.CartItemEntity", b =>
                {
                    b.HasOne("Entities.CartEntity", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("Entities.OrderEntity", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderEntityId");

                    b.HasOne("Entities.ProductEntity", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.OrderEntity", b =>
                {
                    b.HasOne("Entities.DeliveryInfoEntity", "DeliveryInfo")
                        .WithMany()
                        .HasForeignKey("DeliveryInfoId");

                    b.Navigation("DeliveryInfo");
                });

            modelBuilder.Entity("Entities.CartEntity", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Entities.OrderEntity", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
