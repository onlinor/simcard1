using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCard.APP.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name", "ParentId", "ShopId" },
                values: new object[,]
                {
                    { 2, new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(1634), null, "Sim Toàn Cầu", null, null },
                    { 3, new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(1646), null, "Alo Sim", null, null },
                    { 4, new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(1646), null, "Sim Thần Tài", null, null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(2684), null, "Viettel" },
                    { 2, new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(3529), null, "Vinaphone" },
                    { 3, new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(3542), null, "Mobiphone" },
                    { 4, new DateTime(2019, 4, 21, 20, 13, 4, 543, DateTimeKind.Local).AddTicks(3546), null, "Vietnam Mobile" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Password", "PasswordSalt" },
                values: new object[] { new DateTime(2019, 4, 21, 20, 13, 4, 519, DateTimeKind.Local).AddTicks(822), "AtgXNEFlyLoiygTh3+B616NPWd//fG1jSAKzzy6qIy4=", "FUVOCcxpOrHQKmDQHdCUtQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Password", "PasswordSalt" },
                values: new object[] { new DateTime(2019, 4, 21, 20, 13, 4, 534, DateTimeKind.Local).AddTicks(5402), "AtgXNEFlyLoiygTh3+B616NPWd//fG1jSAKzzy6qIy4=", "FUVOCcxpOrHQKmDQHdCUtQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 4, 21, 20, 2, 7, 198, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Password", "PasswordSalt" },
                values: new object[] { new DateTime(2019, 4, 21, 20, 2, 7, 175, DateTimeKind.Local).AddTicks(4289), "Q/23y6SfO19Anh7mlQfJvf7+gFg0xwRcMTD3k/WX2lw=", "4BXpXdgyhZIF8ZVcN2rFOw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Password", "PasswordSalt" },
                values: new object[] { new DateTime(2019, 4, 21, 20, 2, 7, 188, DateTimeKind.Local).AddTicks(4356), "Q/23y6SfO19Anh7mlQfJvf7+gFg0xwRcMTD3k/WX2lw=", "4BXpXdgyhZIF8ZVcN2rFOw==" });
        }
    }
}
