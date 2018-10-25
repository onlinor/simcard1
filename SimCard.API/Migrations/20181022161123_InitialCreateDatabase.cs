using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace simcard.api.Migrations
{
    public partial class InitialCreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tenCH = table.Column<string>(nullable: true),
                    diachiCH = table.Column<string>(nullable: true),
                    hoTen = table.Column<string>(nullable: true),
                    sdt1 = table.Column<string>(nullable: true),
                    sdt2 = table.Column<string>(nullable: true),
                    maKH = table.Column<string>(nullable: true),
                    matheTV = table.Column<string>(nullable: true),
                    tenCongTy = table.Column<string>(nullable: true),
                    masoThue = table.Column<string>(nullable: true),
                    diachiHoaDon = table.Column<string>(nullable: true),
                    nguonDen = table.Column<string>(nullable: true),
                    ngGioiThieu = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    fb = table.Column<string>(nullable: true),
                    zalo = table.Column<string>(nullable: true),
                    ngayDen = table.Column<DateTime>(nullable: false),
                    ngaySinh = table.Column<DateTime>(nullable: false),
                    gioiTinh = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ShopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShopId",
                table: "Product",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Shop");
        }
    }
}
