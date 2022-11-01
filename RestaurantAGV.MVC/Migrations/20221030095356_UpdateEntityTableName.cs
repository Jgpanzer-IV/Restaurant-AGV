using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAGV.MVC.Migrations
{
    public partial class UpdateEntityTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTables_TableId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerTables",
                table: "CustomerTables");

            migrationBuilder.RenameTable(
                name: "CustomerTables",
                newName: "Tables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tables_TableId",
                table: "Customers",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tables_TableId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "CustomerTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerTables",
                table: "CustomerTables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTables_TableId",
                table: "Customers",
                column: "TableId",
                principalTable: "CustomerTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
