using Microsoft.EntityFrameworkCore.Migrations;

namespace inGear.Migrations
{
    public partial class addCategoriesConditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Label" },
                values: new object[,]
                {
                    { 1, "Electric Guitars" },
                    { 13, "Services" },
                    { 12, "Accessories" },
                    { 11, "Band and Orchestra" },
                    { 10, "Folk" },
                    { 8, "Keyboards and Synths" },
                    { 9, "DJ and Lighting Gear" },
                    { 6, "Drums and Percussion" },
                    { 5, "Effects and Pedals" },
                    { 4, "Amps" },
                    { 3, "Bass Guitars" },
                    { 2, "Acoustic Guitars" },
                    { 7, "Pro Audio" }
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "ConditionId", "Label" },
                values: new object[,]
                {
                    { 4, "Excellent with no noticable cosmetic damage" },
                    { 1, "Poor but functioning" },
                    { 2, "Fair but noticable cosmetic damage" },
                    { 3, "Good with minor cosmetic damage" },
                    { 5, "Mint condition" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ConditionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ConditionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ConditionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ConditionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ConditionId",
                keyValue: 5);
        }
    }
}
