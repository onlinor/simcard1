using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCard.APP.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bankbook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    MaCH = table.Column<string>(maxLength: 255, nullable: true),
                    TenCH = table.Column<string>(maxLength: 255, nullable: true),
                    GiaTri = table.Column<string>(maxLength: 255, nullable: false),
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    TenCH = table.Column<string>(maxLength: 255, nullable: true),
                    DiachiCH = table.Column<string>(maxLength: 255, nullable: true),
                    HoTen = table.Column<string>(maxLength: 255, nullable: false),
                    Sdt1 = table.Column<string>(maxLength: 11, nullable: true),
                    Sdt2 = table.Column<string>(maxLength: 11, nullable: true),
                    MaKH = table.Column<string>(maxLength: 255, nullable: true),
                    MatheTV = table.Column<string>(maxLength: 30, nullable: true),
                    TenCongTy = table.Column<string>(maxLength: 255, nullable: true),
                    MasoThue = table.Column<string>(maxLength: 30, nullable: true),
                    DiachiHoaDon = table.Column<string>(maxLength: 255, nullable: true),
                    NguonDen = table.Column<string>(maxLength: 30, nullable: true),
                    NgGioiThieu = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Fb = table.Column<string>(maxLength: 255, nullable: true),
                    Zalo = table.Column<string>(maxLength: 255, nullable: true),
                    NgayDen = table.Column<DateTime>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GioiTinh = table.Column<bool>(nullable: false)
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    LoaiSK = table.Column<string>(maxLength: 255, nullable: true),
                    MaSK = table.Column<string>(nullable: true),
                    TenSK = table.Column<string>(maxLength: 255, nullable: false),
                    NoiDung = table.Column<string>(maxLength: 255, nullable: true),
                    TgBatDau = table.Column<DateTime>(nullable: false),
                    TgKetThuc = table.Column<DateTime>(nullable: false),
                    DoiTuong = table.Column<string>(maxLength: 255, nullable: true),
                    EventStatus = table.Column<bool>(nullable: false),
                    IsNewEvent = table.Column<bool>(nullable: false),
                    IsCompleteEvent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Ten = table.Column<string>(maxLength: 255, nullable: false),
                    Menhgia = table.Column<int>(nullable: false),
                    Chietkhaudauvao = table.Column<float>(nullable: false),
                    Chietkhaucaonhat = table.Column<float>(nullable: false),
                    Buocnhay = table.Column<float>(nullable: false),
                    Khungtien_1 = table.Column<string>(nullable: true),
                    Khungtien_2 = table.Column<string>(nullable: true),
                    Khungtien_3 = table.Column<string>(nullable: true),
                    Khungtien_4 = table.Column<string>(nullable: true),
                    Khungtien_5 = table.Column<string>(nullable: true),
                    Khungtien_6 = table.Column<string>(nullable: true),
                    Khungtien_7 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExportReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Suffix = table.Column<int>(nullable: false),
                    Nhanvienlap = table.Column<string>(nullable: true),
                    OldDebt = table.Column<decimal>(nullable: false),
                    RepresentativePerson = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    MoneyPaid = table.Column<decimal>(nullable: false),
                    Debt = table.Column<decimal>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ExportToShopId = table.Column<int>(nullable: true),
                    ExportToCustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportReceipts_Customers_ExportToCustomerId",
                        column: x => x.ExportToCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportReceipts_Customers_ExportToShopId",
                        column: x => x.ExportToShopId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportReceipts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Ma = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Suffix = table.Column<int>(nullable: false),
                    Nhanvienlap = table.Column<string>(nullable: true),
                    Congnocu = table.Column<decimal>(nullable: false),
                    Nguoidaidien = table.Column<string>(nullable: true),
                    Sodienthoai = table.Column<int>(nullable: false),
                    Ghichu = table.Column<string>(nullable: true),
                    Tienthanhtoan = table.Column<decimal>(nullable: false),
                    Tienconlai = table.Column<decimal>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportReceipts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportReceipts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Ten = table.Column<string>(maxLength: 255, nullable: false),
                    Ma = table.Column<string>(nullable: true),
                    Menhgia = table.Column<decimal>(nullable: false),
                    Soluong = table.Column<int>(nullable: false),
                    ProductType = table.Column<string>(nullable: true),
                    Gianhap = table.Column<decimal>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExportReceiptProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ChietKhau = table.Column<decimal>(nullable: false),
                    ExportReceiptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportReceiptProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportReceiptProducts_ExportReceipts_ExportReceiptId",
                        column: x => x.ExportReceiptId,
                        principalTable: "ExportReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportReceiptProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportReceiptProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ChietKhau = table.Column<decimal>(nullable: false),
                    ImportReceiptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceiptProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportReceiptProducts_ImportReceipts_ImportReceiptId",
                        column: x => x.ImportReceiptId,
                        principalTable: "ImportReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportReceiptProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportReceiptProducts_ExportReceiptId",
                table: "ExportReceiptProducts",
                column: "ExportReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportReceiptProducts_ProductId",
                table: "ExportReceiptProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportReceipts_ExportToCustomerId",
                table: "ExportReceipts",
                column: "ExportToCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportReceipts_ExportToShopId",
                table: "ExportReceipts",
                column: "ExportToShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportReceipts_ShopId",
                table: "ExportReceipts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceiptProducts_ImportReceiptId",
                table: "ImportReceiptProducts",
                column: "ImportReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceiptProducts_ProductId",
                table: "ImportReceiptProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceipts_ShopId",
                table: "ImportReceipts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceipts_SupplierId",
                table: "ImportReceipts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ShopId",
                table: "Shops",
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
                name: "Events");

            migrationBuilder.DropTable(
                name: "ExportReceiptProducts");

            migrationBuilder.DropTable(
                name: "ImportReceiptProducts");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "ExportReceipts");

            migrationBuilder.DropTable(
                name: "ImportReceipts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
