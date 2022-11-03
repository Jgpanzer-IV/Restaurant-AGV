using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAGV.MVC.Migrations
{
    public partial class AddMenustatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuantityStatuses_PurchasedMenues_PurchasedMenuId",
                table: "QuantityStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuantityStatuses",
                table: "QuantityStatuses");

            migrationBuilder.RenameTable(
                name: "QuantityStatuses",
                newName: "MenusStatus");

            migrationBuilder.RenameIndex(
                name: "IX_QuantityStatuses_PurchasedMenuId",
                table: "MenusStatus",
                newName: "IX_MenusStatus_PurchasedMenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenusStatus",
                table: "MenusStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenusStatus_PurchasedMenues_PurchasedMenuId",
                table: "MenusStatus",
                column: "PurchasedMenuId",
                principalTable: "PurchasedMenues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenusStatus_PurchasedMenues_PurchasedMenuId",
                table: "MenusStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenusStatus",
                table: "MenusStatus");

            migrationBuilder.RenameTable(
                name: "MenusStatus",
                newName: "QuantityStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_MenusStatus_PurchasedMenuId",
                table: "QuantityStatuses",
                newName: "IX_QuantityStatuses_PurchasedMenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuantityStatuses",
                table: "QuantityStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuantityStatuses_PurchasedMenues_PurchasedMenuId",
                table: "QuantityStatuses",
                column: "PurchasedMenuId",
                principalTable: "PurchasedMenues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
