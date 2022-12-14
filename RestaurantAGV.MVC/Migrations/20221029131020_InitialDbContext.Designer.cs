// <auto-generated />
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
    [Migration("20221029131020_InitialDbContext")]
    partial class InitialDbContext
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

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("TableId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.BillOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BillingTime")
                        .HasColumnType("TEXT");

                    b.Property<byte>("CountingOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<double>("Discount")
                        .HasColumnType("money");

                    b.Property<double>("OrderPrice")
                        .HasColumnType("money");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("money");

                    b.Property<double>("VatPrice")
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

                    b.Property<DateTime>("TimeCheckIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TimeCheckOut")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

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

                    b.ToTable("CustomerTables");
                });

            modelBuilder.Entity("RestaurantAGV.MVC.Models.Entities.Basket", b =>
                {
                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Customer", "Customer")
                        .WithOne("Basket")
                        .HasForeignKey("RestaurantAGV.MVC.Models.Entities.Basket", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantAGV.MVC.Models.Entities.Table", "Table")
                        .WithMany("Baskets")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");
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
                    b.Navigation("Baskets");
                });
#pragma warning restore 612, 618
        }
    }
}
