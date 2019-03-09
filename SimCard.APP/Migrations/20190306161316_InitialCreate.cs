using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCard.APP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bankbook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    TenKhachHang = table.Column<string>(maxLength: 255, nullable: true),
                    MaKhachHang = table.Column<string>(maxLength: 255, nullable: true),
                    MaPhieu = table.Column<string>(maxLength: 255, nullable: true),
                    NoiDungPhieu = table.Column<string>(maxLength: 255, nullable: true),
                    SoTienThu = table.Column<int>(nullable: false),
                    SoTienChi = table.Column<int>(nullable: false),
                    CongDon = table.Column<int>(nullable: false),
                    DonViNop = table.Column<string>(maxLength: 255, nullable: true),
                    DonViNhan = table.Column<string>(maxLength: 255, nullable: true),
                    HinhThucNop = table.Column<string>(maxLength: 255, nullable: true),
                    HinhThucChi = table.Column<string>(maxLength: 255, nullable: true),
                    NguoiChi = table.Column<string>(maxLength: 255, nullable: true),
                    NguoiThu = table.Column<string>(maxLength: 255, nullable: true),
                    GhiChu = table.Column<string>(maxLength: 255, nullable: true),
                    LoaiNganHang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankbook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cashbook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NgayLap = table.Column<DateTime>(nullable: true),
                    TenKhachHang = table.Column<string>(maxLength: 255, nullable: true),
                    MaKhachHang = table.Column<string>(maxLength: 255, nullable: true),
                    MaPhieu = table.Column<string>(maxLength: 255, nullable: true),
                    NoiDungPhieu = table.Column<string>(maxLength: 255, nullable: true),
                    SoTienThu = table.Column<int>(nullable: false),
                    SoTienChi = table.Column<int>(nullable: false),
                    CongDon = table.Column<int>(nullable: false),
                    DonViNop = table.Column<string>(maxLength: 255, nullable: true),
                    DonViNhan = table.Column<string>(maxLength: 255, nullable: true),
                    HinhThucNop = table.Column<string>(maxLength: 255, nullable: true),
                    HinhThucChi = table.Column<string>(maxLength: 255, nullable: true),
                    NguoiChi = table.Column<string>(maxLength: 255, nullable: true),
                    NguoiThu = table.Column<string>(maxLength: 255, nullable: true),
                    GhiChu = table.Column<string>(maxLength: 255, nullable: true),
                    LoaiNganHang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashbook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaCH = table.Column<string>(maxLength: 255, nullable: true),
                    TenCH = table.Column<string>(maxLength: 255, nullable: true),
                    GiaTri = table.Column<string>(maxLength: 255, nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(maxLength: 255, nullable: true),
                    ShopID = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tenCH = table.Column<string>(maxLength: 255, nullable: true),
                    diachiCH = table.Column<string>(maxLength: 255, nullable: true),
                    hoTen = table.Column<string>(maxLength: 255, nullable: false),
                    sdt1 = table.Column<string>(maxLength: 11, nullable: true),
                    sdt2 = table.Column<string>(maxLength: 11, nullable: true),
                    maKH = table.Column<string>(maxLength: 255, nullable: true),
                    matheTV = table.Column<string>(maxLength: 30, nullable: true),
                    tenCongTy = table.Column<string>(maxLength: 255, nullable: true),
                    masoThue = table.Column<string>(maxLength: 30, nullable: true),
                    diachiHoaDon = table.Column<string>(maxLength: 255, nullable: true),
                    nguonDen = table.Column<string>(maxLength: 30, nullable: true),
                    ngGioiThieu = table.Column<string>(maxLength: 255, nullable: true),
                    email = table.Column<string>(maxLength: 255, nullable: true),
                    fb = table.Column<string>(maxLength: 255, nullable: true),
                    zalo = table.Column<string>(maxLength: 255, nullable: true),
                    ngayDen = table.Column<DateTime>(nullable: false),
                    ngaySinh = table.Column<DateTime>(nullable: false),
                    gioiTinh = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoaiSK = table.Column<string>(maxLength: 255, nullable: true),
                    MaSK = table.Column<string>(nullable: true),
                    TenSK = table.Column<string>(maxLength: 255, nullable: false),
                    NoiDung = table.Column<string>(maxLength: 255, nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: false),
                    TgBatDau = table.Column<DateTime>(nullable: false),
                    TgKetThuc = table.Column<DateTime>(nullable: false),
                    DoiTuong = table.Column<string>(maxLength: 255, nullable: true),
                    EventStatus = table.Column<bool>(nullable: false),
                    isNewEvent = table.Column<bool>(nullable: false),
                    isCompleteEvent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
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
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    BuyingPrice = table.Column<decimal>(nullable: false),
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
                name: "Bankbook");

            migrationBuilder.DropTable(
                name: "Cashbook");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Shop");
        }
    }
}
