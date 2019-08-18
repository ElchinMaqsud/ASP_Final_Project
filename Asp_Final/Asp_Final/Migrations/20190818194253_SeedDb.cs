using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_Final.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bans",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Hatchback" },
                    { 5, "Sedan" },
                    { 6, "Van" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Baku" },
                    { 8, "Sumgayit" },
                    { 9, "Barda" },
                    { 10, "Gence" },
                    { 11, "Semkir" },
                    { 12, "Naxcivan" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "Green" },
                    { 14, "Red" },
                    { 13, "Brown" },
                    { 15, "Blue" },
                    { 11, "Yellow" },
                    { 10, "White" },
                    { 9, "Black" },
                    { 12, "Gray" }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Gasoline" },
                    { 5, "Diesel" },
                    { 6, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 14, "Lada(VAZ)" },
                    { 13, "Chevrolet" },
                    { 12, "Hyundai" },
                    { 9, "Mercedes" },
                    { 10, "Audi" },
                    { 8, "Bmw" },
                    { 11, "Kia" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Info", "PhotoUrl", "Title" },
                values: new object[,]
                {
                    { 15, "New Kia Soul Full Edition 2019", "KiaSoul.jpg", "New Kia Soul 2019" },
                    { 16, "New Ferrari  Full Sport Edition 2019", "Ferrari.jpg", "New Ferrari SpeedCar 2019" }
                });

            migrationBuilder.InsertData(
                table: "SpeedBoxes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Automatic" },
                    { 4, "Mechanic" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MarkId", "Name" },
                values: new object[,]
                {
                    { 26, 8, "530" },
                    { 45, 14, "2107" },
                    { 43, 13, "Cruze" },
                    { 42, 13, "Captiva" },
                    { 41, 13, "Aveo" },
                    { 40, 12, "Accent" },
                    { 39, 12, "Santa-fe" },
                    { 38, 12, "Elantra" },
                    { 37, 11, "Optima" },
                    { 46, 14, "Niva" },
                    { 36, 11, "Sorento" },
                    { 34, 10, "Q7" },
                    { 33, 10, "A6" },
                    { 32, 10, "A4" },
                    { 31, 9, "XD-250" },
                    { 30, 9, "E-220" },
                    { 29, 9, "C-220" },
                    { 28, 8, "M6" },
                    { 27, 8, "X5" },
                    { 35, 11, "Cerato" },
                    { 47, 14, "Prioa" }
                });

            migrationBuilder.InsertData(
                table: "Automobiles",
                columns: new[] { "Id", "ApplicationUserId", "BanId", "CityId", "ColorId", "EnginePower", "EngineVolume", "FuelId", "GraduationYear", "IsNew", "Mileage", "ModelId", "Name", "PhotoUrl", "Price", "SpeedBoxId" },
                values: new object[] { 5, null, 5, 8, 9, 200, 2400m, 4, new DateTime(2013, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 25000, 37, "Kia Optima", "Kia.jpg", 20000m, 3 });

            migrationBuilder.InsertData(
                table: "CarImages",
                columns: new[] { "Id", "AutomobileId", "CarPhotoUrl" },
                values: new object[] { 20, 5, "Kia1.jpg" });

            migrationBuilder.InsertData(
                table: "CarImages",
                columns: new[] { "Id", "AutomobileId", "CarPhotoUrl" },
                values: new object[] { 21, 5, "Kia2.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CarImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Fuels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fuels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SpeedBoxes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Automobiles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Bans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Fuels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SpeedBoxes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
