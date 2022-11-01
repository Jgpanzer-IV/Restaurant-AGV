using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAGV.MVC.Migrations
{
    public partial class UpdateEntitiesReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_CustomerTables_TableId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_TableId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Baskets");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TableId",
                table: "Customers",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTables_TableId",
                table: "Customers",
                column: "TableId",
                principalTable: "CustomerTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTables_TableId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TableId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_TableId",
                table: "Baskets",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_CustomerTables_TableId",
                table: "Baskets",
                column: "TableId",
                principalTable: "CustomerTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
