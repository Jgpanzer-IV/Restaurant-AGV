using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAGV.MVC.Migrations
{
    public partial class AddNewEntitiesForCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "Meat" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "Meat with Vegetable" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 3, "Vegetable" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 4, "Seafood" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 5, "Seafood with Vegetable" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 6, "Dessert" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 7, "Drink" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Address", "ChairQuantity", "DistantMeter", "IsReserved", "NumberTable" },
                values: new object[] { 1, "In Room", (byte)4, 30, false, "01" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Address", "ChairQuantity", "DistantMeter", "IsReserved", "NumberTable" },
                values: new object[] { 2, "In Room", (byte)4, 40, false, "02" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Address", "ChairQuantity", "DistantMeter", "IsReserved", "NumberTable" },
                values: new object[] { 3, "In Room", (byte)4, 60, false, "03" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Address", "ChairQuantity", "DistantMeter", "IsReserved", "NumberTable" },
                values: new object[] { 4, "In Room", (byte)4, 70, false, "04" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Address", "ChairQuantity", "DistantMeter", "IsReserved", "NumberTable" },
                values: new object[] { 5, "Out Door", (byte)2, 100, false, "01" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Address", "ChairQuantity", "DistantMeter", "IsReserved", "NumberTable" },
                values: new object[] { 6, "Out Door", (byte)2, 120, false, "02" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 1, "This menu have created from the principle of Saral Castle.", 1, "Fried Pork with Garlic Pepper", 19.449999999999999, "/images/fried-pork-with-garlic-pepper.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 2, "If you are not looking for special time, Then this is right for you.", 5, "American Shrimp Fried Rice", 5.25, "/images/american-shrimp-fried-rice.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 3, "This rolling spring will give you a special time and improve your healty.", 3, "Fried Spring Rolls", 12.199999999999999, "/images/fried-spring-rolls.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 4, "The vegetable with pork combind each other as well from Thailand.", 2, "Stir Fried Kale Spicy Crispy Pork", 7.6600000000000001, "/images/stir-fried-kale-spicy-crispy-pork.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 5, "The coffee selected from the true nature to serve the best for you.", 7, "Coffee with Pearl", 4.2300000000000004, "/images/coffee-drink.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 6, "This green tea have no caffeine as a component.", 7, "Green tea with Milk", 3.3199999999999998, "/images/green-tea-drink.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 7, "This is a menu for who need to improve their healty.", 7, "Orange juice", 2.8900000000000001, "/images/orange-drink.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 8, "For anyone who love chocolat.", 6, "Chocolat Cake", 4.4199999999999999, "/images/sweet-chocolet-cake.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 9, "This cake is for the anyone who want to have a special time with dessert.", 6, "Molten Cake", 6.6399999999999997, "/images/sweet-molten-cake.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 10, "The dessert from the chainaland.", 6, "Yuan Assortment", 5.2300000000000004, "/images/sweet-tang-yuan-assortment.jpg" });

            migrationBuilder.InsertData(
                table: "Menues",
                columns: new[] { "Id", "Description", "MenuCategoryId", "MenuName", "Price", "UriImage" },
                values: new object[] { 11, "The Original Dessert from chainaland", 6, "Yuan Composition", 4.6799999999999997, "/images/sweet-tang-yuan-composition.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Menues",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
