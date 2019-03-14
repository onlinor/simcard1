﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimCard.API.Persistence;

namespace SimCard.APP.Migrations
{
    [DbContext(typeof(SimCardDBContext))]
    partial class SimCardDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("SimCard.API.Models.Bankbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CongDon");

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

                    b.Property<DateTime>("NgayLap");

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

            modelBuilder.Entity("SimCard.API.Models.Cashbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CongDon");

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

                    b.Property<DateTime?>("NgayLap");

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

            modelBuilder.Entity("SimCard.API.Models.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu")
                        .HasMaxLength(255);

                    b.Property<string>("GiaTri")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MaCH")
                        .HasMaxLength(255);

                    b.Property<DateTime>("NgayTao");

                    b.Property<string>("ShopID")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("TenCH")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("SimCard.API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("diachiCH")
                        .HasMaxLength(255);

                    b.Property<string>("diachiHoaDon")
                        .HasMaxLength(255);

                    b.Property<string>("email")
                        .HasMaxLength(255);

                    b.Property<string>("fb")
                        .HasMaxLength(255);

                    b.Property<bool>("gioiTinh");

                    b.Property<string>("hoTen")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("maKH")
                        .HasMaxLength(255);

                    b.Property<string>("masoThue")
                        .HasMaxLength(30);

                    b.Property<string>("matheTV")
                        .HasMaxLength(30);

                    b.Property<string>("ngGioiThieu")
                        .HasMaxLength(255);

                    b.Property<DateTime>("ngayDen");

                    b.Property<DateTime>("ngaySinh");

                    b.Property<string>("nguonDen")
                        .HasMaxLength(30);

                    b.Property<string>("sdt1")
                        .HasMaxLength(11);

                    b.Property<string>("sdt2")
                        .HasMaxLength(11);

                    b.Property<string>("tenCH")
                        .HasMaxLength(255);

                    b.Property<string>("tenCongTy")
                        .HasMaxLength(255);

                    b.Property<string>("zalo")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SimCard.API.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DoiTuong")
                        .HasMaxLength(255);

                    b.Property<bool>("EventStatus");

                    b.Property<string>("LoaiSK")
                        .HasMaxLength(255);

                    b.Property<string>("MaSK");

                    b.Property<DateTime>("NgayTao");

                    b.Property<string>("NoiDung")
                        .HasMaxLength(255);

                    b.Property<string>("TenSK")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("TgBatDau");

                    b.Property<DateTime>("TgKetThuc");

                    b.Property<bool>("isCompleteEvent");

                    b.Property<bool>("isNewEvent");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SimCard.API.Models.Network", b =>
                {
                    b.Property<string>("Ma")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Buocnhay");

                    b.Property<float>("Chietkhaucaonhat");

                    b.Property<float>("Chietkhaudauvao");

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

                    b.HasKey("Ma");

                    b.ToTable("Network");
                });

            modelBuilder.Entity("SimCard.API.Models.Phieunhap", b =>
                {
                    b.Property<string>("Prefixid");

                    b.Property<int>("Suffixid");

                    b.Property<decimal>("Congnocu");

                    b.Property<string>("Ghichu");

                    b.Property<DateTime>("Ngaylap");

                    b.Property<string>("Nguoidaidien");

                    b.Property<string>("Nhanvienlap");

                    b.Property<int>("Sodienthoai");

                    b.Property<string>("Tennhacungcap");

                    b.Property<decimal>("Tienconlai");

                    b.Property<decimal>("Tienthanhtoan");

                    b.HasKey("Prefixid", "Suffixid");

                    b.ToTable("Phieunhap");
                });

            modelBuilder.Entity("SimCard.API.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("PhieunhapPrefixid");

                    b.Property<int?>("PhieunhapSuffixid");

                    b.Property<int>("Quantity");

                    b.Property<int?>("ShopId");

                    b.Property<int>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("PhieunhapPrefixid", "PhieunhapSuffixid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SimCard.API.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("SimCard.API.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Note");

                    b.HasKey("Id");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("SimCard.API.Models.Product", b =>
                {
                    b.HasOne("SimCard.API.Models.Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId");

                    b.HasOne("SimCard.API.Models.Phieunhap")
                        .WithMany("Dssanpham")
                        .HasForeignKey("PhieunhapPrefixid", "PhieunhapSuffixid");
                });
#pragma warning restore 612, 618
        }
    }
}
