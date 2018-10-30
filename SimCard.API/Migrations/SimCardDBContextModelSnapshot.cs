﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimCard.API.Persistence;

namespace simcard.api.Migrations
{
    [DbContext(typeof(SimCardDBContext))]
    partial class SimCardDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

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
                        .IsRequired()
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

            modelBuilder.Entity("SimCard.API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

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

            modelBuilder.Entity("SimCard.API.Models.Product", b =>
                {
                    b.HasOne("SimCard.API.Models.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
