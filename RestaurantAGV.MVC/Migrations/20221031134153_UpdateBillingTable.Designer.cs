﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantAGV.MVC.Database;

#nullable disable

namespace RestaurantAGV.MVC.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20221031134153_UpdateBillingTable")]
    partial class UpdateBillingTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.AGVStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Battery")
                        .HasColumnType("REAL");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvaliable")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AGVsStatus");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.BillOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BillingSlipUri")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BillingTime")
                        .HasColumnType("TEXT");

                    b.Property<byte?>("CountingOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<double?>("Discount")
                        .HasColumnType("money");

                    b.Property<double?>("OrderPrice")
                        .HasColumnType("money");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("money");

                    b.Property<double?>("VatPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("BillOrders");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Cook", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Cooks");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<bool>("BillingDone")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("CustomerCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeCheckIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TimeCheckOut")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("FistName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<int>("MenuCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("money");

                    b.Property<string>("UriImage")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MenuCategoryId");

                    b.ToTable("Menues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This menu have created from the principle of Saral Castle.",
                            MenuCategoryId = 1,
                            MenuName = "Fried Pork with Garlic Pepper",
                            Price = 19.449999999999999,
                            UriImage = "/images/fried-pork-with-garlic-pepper.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "If you are not looking for special time, Then this is right for you.",
                            MenuCategoryId = 5,
                            MenuName = "American Shrimp Fried Rice",
                            Price = 5.25,
                            UriImage = "/images/american-shrimp-fried-rice.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This rolling spring will give you a special time and improve your healty.",
                            MenuCategoryId = 3,
                            MenuName = "Fried Spring Rolls",
                            Price = 12.199999999999999,
                            UriImage = "/images/fried-spring-rolls.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The vegetable with pork combind each other as well from Thailand.",
                            MenuCategoryId = 2,
                            MenuName = "Stir Fried Kale Spicy Crispy Pork",
                            Price = 7.6600000000000001,
                            UriImage = "/images/stir-fried-kale-spicy-crispy-pork.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The coffee selected from the true nature to serve the best for you.",
                            MenuCategoryId = 7,
                            MenuName = "Coffee with Pearl",
                            Price = 4.2300000000000004,
                            UriImage = "/images/coffee-drink.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Description = "This green tea have no caffeine as a component.",
                            MenuCategoryId = 7,
                            MenuName = "Green tea with Milk",
                            Price = 3.3199999999999998,
                            UriImage = "/images/green-tea-drink.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Description = "This is a menu for who need to improve their healty.",
                            MenuCategoryId = 7,
                            MenuName = "Orange juice",
                            Price = 2.8900000000000001,
                            UriImage = "/images/orange-drink.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Description = "For anyone who love chocolat.",
                            MenuCategoryId = 6,
                            MenuName = "Chocolat Cake",
                            Price = 4.4199999999999999,
                            UriImage = "/images/sweet-chocolet-cake.jpg"
                        },
                        new
                        {
                            Id = 9,
                            Description = "This cake is for the anyone who want to have a special time with dessert.",
                            MenuCategoryId = 6,
                            MenuName = "Molten Cake",
                            Price = 6.6399999999999997,
                            UriImage = "/images/sweet-molten-cake.jpg"
                        },
                        new
                        {
                            Id = 10,
                            Description = "The dessert from the chainaland.",
                            MenuCategoryId = 6,
                            MenuName = "Yuan Assortment",
                            Price = 5.2300000000000004,
                            UriImage = "/images/sweet-tang-yuan-assortment.jpg"
                        },
                        new
                        {
                            Id = 11,
                            Description = "The Original Dessert from chainaland",
                            MenuCategoryId = 6,
                            MenuName = "Yuan Composition",
                            Price = 4.6799999999999997,
                            UriImage = "/images/sweet-tang-yuan-composition.jpg"
                        });
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.MenuCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MenuCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Meat"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Meat with Vegetable"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Vegetable"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Seafood"
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Seafood with Vegetable"
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Dessert"
                        },
                        new
                        {
                            Id = 7,
                            CategoryName = "Drink"
                        });
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.MenusStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFinish")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PurchasedMenuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PurchasedMenuId");

                    b.ToTable("QuantityStatuses");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Phone", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("PhoneNumber");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Position", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Salary")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WorkingTimeIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WorkingTimeOut")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.PurchasedMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BasketId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CookId")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFinish")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenuNameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<int>("PurchasedOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("CookId");

                    b.HasIndex("MenuNameId");

                    b.HasIndex("PurchasedOrderId");

                    b.ToTable("PurchasedMenues");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.PurchasedOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<bool>("CustomerStatus")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAllFinish")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PurchasedTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Queue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReceiverId")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<bool>("ReceiverStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("PurchasedOrders");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Receiver", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Receivers");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.SelectedMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BasketId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("MenuId");

                    b.ToTable("SelectedMenus");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<byte>("ChairQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DistantMeter")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumberTable")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "In Room",
                            ChairQuantity = (byte)4,
                            DistantMeter = 30,
                            IsReserved = false,
                            NumberTable = "01"
                        },
                        new
                        {
                            Id = 2,
                            Address = "In Room",
                            ChairQuantity = (byte)4,
                            DistantMeter = 40,
                            IsReserved = false,
                            NumberTable = "02"
                        },
                        new
                        {
                            Id = 3,
                            Address = "In Room",
                            ChairQuantity = (byte)4,
                            DistantMeter = 60,
                            IsReserved = false,
                            NumberTable = "03"
                        },
                        new
                        {
                            Id = 4,
                            Address = "In Room",
                            ChairQuantity = (byte)4,
                            DistantMeter = 70,
                            IsReserved = false,
                            NumberTable = "04"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Out Door",
                            ChairQuantity = (byte)2,
                            DistantMeter = 100,
                            IsReserved = false,
                            NumberTable = "01"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Out Door",
                            ChairQuantity = (byte)2,
                            DistantMeter = 120,
                            IsReserved = false,
                            NumberTable = "02"
                        });
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Basket", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Customer", "Customer")
                        .WithOne("Basket")
                        .HasForeignKey("RestaurantAGV.MVC.Models.Entities.Basket", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.BillOrder", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Customer", "Customer")
                        .WithOne("BillOrder")
                        .HasForeignKey("RestaurantAGV.MVC.Models.Entities.BillOrder", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Cook", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Department", "Department")
                        .WithMany("Cooks")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Employee", "Employee")
                        .WithMany("Cooks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Position", "Position")
                        .WithMany("Cooks")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Customer", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Table", "Table")
                        .WithMany("Customers")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Menu", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.MenuCategory", "MenuCategory")
                        .WithMany("Menus")
                        .HasForeignKey("MenuCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuCategory");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.MenusStatus", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.PurchasedMenu", "PurchasedMenu")
                        .WithMany("MenusStatus")
                        .HasForeignKey("PurchasedMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchasedMenu");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Phone", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Employee", "Employee")
                        .WithMany("Phones")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.PurchasedMenu", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Basket", "Basket")
                        .WithMany("PurchasedMenus")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Cook", "Cook")
                        .WithMany("PurchasedMenu")
                        .HasForeignKey("CookId");

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Menu", "Menu")
                        .WithMany("PurchasedMenus")
                        .HasForeignKey("MenuNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.PurchasedOrder", "PurchasedOrder")
                        .WithMany("PurchasedMenus")
                        .HasForeignKey("PurchasedOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Cook");

                    b.Navigation("Menu");

                    b.Navigation("PurchasedOrder");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.PurchasedOrder", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Customer", "Customer")
                        .WithMany("PurchasedOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Receiver", "Receiver")
                        .WithMany("PurchasedOrders")
                        .HasForeignKey("ReceiverId");

                    b.Navigation("Customer");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Receiver", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Department", "Department")
                        .WithMany("Receivers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Employee", "Employee")
                        .WithMany("Receivers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Position", "Position")
                        .WithMany("Receivers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.SelectedMenu", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Basket", "Basket")
                        .WithMany("SelectedMenus")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Menu", "Menu")
                        .WithMany("SelectedMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Basket", b =>
                {
                    b.Navigation("PurchasedMenus");

                    b.Navigation("SelectedMenus");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Cook", b =>
                {
                    b.Navigation("PurchasedMenu");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Customer", b =>
                {
                    b.Navigation("Basket");

                    b.Navigation("BillOrder");

                    b.Navigation("PurchasedOrders");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Department", b =>
                {
                    b.Navigation("Cooks");

                    b.Navigation("Receivers");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Employee", b =>
                {
                    b.Navigation("Cooks");

                    b.Navigation("Phones");

                    b.Navigation("Receivers");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Menu", b =>
                {
                    b.Navigation("PurchasedMenus");

                    b.Navigation("SelectedMenus");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.MenuCategory", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Position", b =>
                {
                    b.Navigation("Cooks");

                    b.Navigation("Receivers");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.PurchasedMenu", b =>
                {
                    b.Navigation("MenusStatus");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.PurchasedOrder", b =>
                {
                    b.Navigation("PurchasedMenus");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Receiver", b =>
                {
                    b.Navigation("PurchasedOrders");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Table", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
