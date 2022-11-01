using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAGV.MVC.Migrations
{
    public partial class InitialDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGVsStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodeName = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Battery = table.Column<float>(type: "REAL", nullable: true),
                    IsAvaliable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGVsStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    CustomerCount = table.Column<byte>(type: "INTEGER", nullable: false),
                    TimeCheckIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeCheckOut = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BillingDone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    NumberTable = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    ChairQuantity = table.Column<byte>(type: "INTEGER", nullable: false),
                    DistantMeter = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReserved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    FistName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Salary = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkingTimeIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkingTimeOut = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BillingTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CountingOrder = table.Column<byte>(type: "INTEGER", nullable: false),
                    OrderPrice = table.Column<double>(type: "money", nullable: false),
                    VatPrice = table.Column<double>(type: "money", nullable: false),
                    Discount = table.Column<double>(type: "money", nullable: false),
                    TotalPrice = table.Column<double>(type: "money", nullable: false),
                    CustomerId = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TableId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baskets_CustomerTables_TableId",
                        column: x => x.TableId,
                        principalTable: "CustomerTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneNumber);
                    table.ForeignKey(
                        name: "FK_Phones_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Price = table.Column<double>(type: "money", nullable: false),
                    UriImage = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    MenuCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menues_MenuCategories_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalTable: "MenuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    PositionId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooks_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cooks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cooks_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    PositionId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receivers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receivers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BasketId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedMenus_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedMenus_Menues_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceiverStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    CustomerStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAllFinish = table.Column<bool>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<double>(type: "money", nullable: false),
                    PurchasedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Queue = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceiverId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    CustomerId = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedOrders_Receivers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchasedMenues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    IsFinish = table.Column<bool>(type: "INTEGER", nullable: false),
                    BasketId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuNameId = table.Column<int>(type: "INTEGER", nullable: false),
                    PurchasedOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    CookId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedMenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedMenues_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedMenues_Cooks_CookId",
                        column: x => x.CookId,
                        principalTable: "Cooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchasedMenues_Menues_MenuNameId",
                        column: x => x.MenuNameId,
                        principalTable: "Menues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedMenues_PurchasedOrders_PurchasedOrderId",
                        column: x => x.PurchasedOrderId,
                        principalTable: "PurchasedOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuantityStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsFinish = table.Column<bool>(type: "INTEGER", nullable: false),
                    PurchasedMenuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuantityStatuses_PurchasedMenues_PurchasedMenuId",
                        column: x => x.PurchasedMenuId,
                        principalTable: "PurchasedMenues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerId",
                table: "Baskets",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_TableId",
                table: "Baskets",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOrders_CustomerId",
                table: "BillOrders",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_DepartmentId",
                table: "Cooks",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_EmployeeId",
                table: "Cooks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_PositionId",
                table: "Cooks",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Menues_MenuCategoryId",
                table: "Menues",
                column: "MenuCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_EmployeeId",
                table: "Phones",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedMenues_BasketId",
                table: "PurchasedMenues",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedMenues_CookId",
                table: "PurchasedMenues",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedMenues_MenuNameId",
                table: "PurchasedMenues",
                column: "MenuNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedMenues_PurchasedOrderId",
                table: "PurchasedMenues",
                column: "PurchasedOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedOrders_CustomerId",
                table: "PurchasedOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedOrders_ReceiverId",
                table: "PurchasedOrders",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityStatuses_PurchasedMenuId",
                table: "QuantityStatuses",
                column: "PurchasedMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_DepartmentId",
                table: "Receivers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_EmployeeId",
                table: "Receivers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_PositionId",
                table: "Receivers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedMenus_BasketId",
                table: "SelectedMenus",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedMenus_MenuId",
                table: "SelectedMenus",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGVsStatus");

            migrationBuilder.DropTable(
                name: "BillOrders");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "QuantityStatuses");

            migrationBuilder.DropTable(
                name: "SelectedMenus");

            migrationBuilder.DropTable(
                name: "PurchasedMenues");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "Menues");

            migrationBuilder.DropTable(
                name: "PurchasedOrders");

            migrationBuilder.DropTable(
                name: "CustomerTables");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
