﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimCard.APP.Persistence;

namespace SimCard.APP.Migrations
{
    [DbContext(typeof(SimCardDBContext))]
    [Migration("20190323123355_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("SimCard.APP.Models.Bankbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CongDon");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("DonViNhan")
                        .HasMaxLength(255);

                    b.Property<string>("DonViNop")
                        .HasMaxLength(255);

                    b.Property<string>("GhiChu")
                        .HasMaxLength(255);

                    b.Property<string>("HinhThucChi")
                        .HasMaxLength(255);

                    b.Property<string>("HinhThucNop")
                        .HasMaxLength(255);

                    b.Property<string>("LoaiNganHang");

                    b.Property<string>("MaKhachHang")
                        .HasMaxLength(255);

                    b.Property<string>("MaPhieu")
                        .HasMaxLength(255);

                    b.Property<string>("NguoiChi")
                        .HasMaxLength(255);

                    b.Property<string>("NguoiThu")
                        .HasMaxLength(255);

                    b.Property<string>("NoiDungPhieu")
                        .HasMaxLength(255);

                    b.Property<int>("SoTienChi");

                    b.Property<int>("SoTienThu");

                    b.Property<string>("TenKhachHang")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Bankbook");
                });

            modelBuilder.Entity("SimCard.APP.Models.Cashbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CongDon");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("DonViNhan")
                        .HasMaxLength(255);

                    b.Property<string>("DonViNop")
                        .HasMaxLength(255);

                    b.Property<string>("GhiChu")
                        .HasMaxLength(255);

                    b.Property<string>("HinhThucChi")
                        .HasMaxLength(255);

                    b.Property<string>("HinhThucNop")
                        .HasMaxLength(255);

                    b.Property<string>("LoaiNganHang");

                    b.Property<string>("MaKhachHang")
                        .HasMaxLength(255);

                    b.Property<string>("MaPhieu")
                        .HasMaxLength(255);

                    b.Property<string>("NguoiChi")
                        .HasMaxLength(255);

                    b.Property<string>("NguoiThu")
                        .HasMaxLength(255);

                    b.Property<string>("NoiDungPhieu")
                        .HasMaxLength(255);

                    b.Property<int>("SoTienChi");

                    b.Property<int>("SoTienThu");

                    b.Property<string>("TenKhachHang")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Cashbook");
                });

            modelBuilder.Entity("SimCard.APP.Models.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(255);

                    b.Property<string>("GiaTri")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MaCH")
                        .HasMaxLength(255);

                    b.Property<string>("ShopID")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("TenCH")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("SimCard.APP.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("DiachiCH")
                        .HasMaxLength(255);

                    b.Property<string>("DiachiHoaDon")
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("Fb")
                        .HasMaxLength(255);

                    b.Property<bool>("GioiTinh");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MaKH")
                        .HasMaxLength(255);

                    b.Property<string>("MasoThue")
                        .HasMaxLength(30);

                    b.Property<string>("MatheTV")
                        .HasMaxLength(30);

                    b.Property<string>("NgGioiThieu")
                        .HasMaxLength(255);

                    b.Property<DateTime>("NgayDen");

                    b.Property<DateTime>("NgaySinh");

                    b.Property<string>("NguonDen")
                        .HasMaxLength(30);

                    b.Property<string>("Sdt1")
                        .HasMaxLength(11);

                    b.Property<string>("Sdt2")
                        .HasMaxLength(11);

                    b.Property<string>("TenCH")
                        .HasMaxLength(255);

                    b.Property<string>("TenCongTy")
                        .HasMaxLength(255);

                    b.Property<string>("Zalo")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SimCard.APP.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("DoiTuong")
                        .HasMaxLength(255);

                    b.Property<bool>("EventStatus");

                    b.Property<bool>("IsCompleteEvent");

                    b.Property<bool>("IsNewEvent");

                    b.Property<string>("LoaiSK")
                        .HasMaxLength(255);

                    b.Property<string>("MaSK");

                    b.Property<string>("NoiDung")
                        .HasMaxLength(255);

                    b.Property<string>("TenSK")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("TgBatDau");

                    b.Property<DateTime>("TgKetThuc");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SimCard.APP.Models.ExportReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<decimal>("Debt");

                    b.Property<int?>("ExportToCustomerId");

                    b.Property<int?>("ExportToShopId");

                    b.Property<decimal>("MoneyPaid");

                    b.Property<string>("Nhanvienlap");

                    b.Property<string>("Note");

                    b.Property<decimal>("OldDebt");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Prefix");

                    b.Property<string>("RepresentativePerson");

                    b.Property<int>("ShopId");

                    b.Property<int>("Suffix");

                    b.HasKey("Id");

                    b.HasIndex("ExportToCustomerId");

                    b.HasIndex("ExportToShopId");

                    b.HasIndex("ShopId");

                    b.ToTable("ExportReceipts");
                });

            modelBuilder.Entity("SimCard.APP.Models.ExportReceiptProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ChietKhau");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("ExportReceiptId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ExportReceiptId");

                    b.HasIndex("ProductId");

                    b.ToTable("ExportReceiptProducts");
                });

            modelBuilder.Entity("SimCard.APP.Models.ImportReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Congnocu");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Ghichu");

                    b.Property<string>("Ma");

                    b.Property<string>("Nguoidaidien");

                    b.Property<string>("Nhanvienlap");

                    b.Property<string>("Prefix");

                    b.Property<int>("ShopId");

                    b.Property<int>("Sodienthoai");

                    b.Property<int>("Suffix");

                    b.Property<int?>("SupplierId");

                    b.Property<decimal>("Tienconlai");

                    b.Property<decimal>("Tienthanhtoan");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ImportReceipts");
                });

            modelBuilder.Entity("SimCard.APP.Models.ImportReceiptProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ChietKhau");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("ImportReceiptId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ImportReceiptId");

                    b.HasIndex("ProductId");

                    b.ToTable("ImportReceiptProducts");
                });

            modelBuilder.Entity("SimCard.APP.Models.Network", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Buocnhay");

                    b.Property<float>("Chietkhaucaonhat");

                    b.Property<float>("Chietkhaudauvao");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Khungtien_1");

                    b.Property<string>("Khungtien_2");

                    b.Property<string>("Khungtien_3");

                    b.Property<string>("Khungtien_4");

                    b.Property<string>("Khungtien_5");

                    b.Property<string>("Khungtien_6");

                    b.Property<string>("Khungtien_7");

                    b.Property<int>("Menhgia");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("SimCard.APP.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<decimal?>("Gianhap");

                    b.Property<string>("Ma");

                    b.Property<decimal>("Menhgia");

                    b.Property<string>("ProductType");

                    b.Property<int?>("ShopId");

                    b.Property<int>("Soluong");

                    b.Property<int?>("SupplierId");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SimCard.APP.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.Property<int?>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("SimCard.APP.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SimCard.APP.Models.ExportReceipt", b =>
                {
                    b.HasOne("SimCard.APP.Models.Customer", "ExportToCustomer")
                        .WithMany()
                        .HasForeignKey("ExportToCustomerId");

                    b.HasOne("SimCard.APP.Models.Customer", "ExportToShop")
                        .WithMany()
                        .HasForeignKey("ExportToShopId");

                    b.HasOne("SimCard.APP.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimCard.APP.Models.ExportReceiptProducts", b =>
                {
                    b.HasOne("SimCard.APP.Models.ExportReceipt")
                        .WithMany("Products")
                        .HasForeignKey("ExportReceiptId");

                    b.HasOne("SimCard.APP.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimCard.APP.Models.ImportReceipt", b =>
                {
                    b.HasOne("SimCard.APP.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimCard.APP.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("SimCard.APP.Models.ImportReceiptProducts", b =>
                {
                    b.HasOne("SimCard.APP.Models.ImportReceipt")
                        .WithMany("Products")
                        .HasForeignKey("ImportReceiptId");

                    b.HasOne("SimCard.APP.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimCard.APP.Models.Product", b =>
                {
                    b.HasOne("SimCard.APP.Models.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId");

                    b.HasOne("SimCard.APP.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("SimCard.APP.Models.Shop", b =>
                {
                    b.HasOne("SimCard.APP.Models.Shop", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ShopId");
                });
#pragma warning restore 612, 618
        }
    }
}
