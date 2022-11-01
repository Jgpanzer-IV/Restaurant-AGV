using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAGV.MVC.Migrations
{
    public partial class UpdateBillingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "VatPrice",
                table: "BillOrders",
                type: "money",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "money");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "BillOrders",
                type: "money",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "money");

            migrationBuilder.AlterColumn<double>(
                name: "OrderPrice",
                table: "BillOrders",
                type: "money",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "money");

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "BillOrders",
                type: "money",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "money");

            migrationBuilder.AlterColumn<byte>(
                name: "CountingOrder",
                table: "BillOrders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BillingTime",
                table: "BillOrders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "BillingSlipUri",
                table: "BillOrders",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingSlipUri",
                table: "BillOrders");

            migrationBuilder.AlterColumn<double>(
                name: "VatPrice",
                table: "BillOrders",
                type: "money",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "BillOrders",
                type: "money",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OrderPrice",
                table: "BillOrders",
                type: "money",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "BillOrders",
                type: "money",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "CountingOrder",
                table: "BillOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BillingTime",
                table: "BillOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
