﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimCard.API.Persistence;

namespace simcard.api.Migrations
{
    [DbContext(typeof(SimCardDBContext))]
    [Migration("20181025024806_addProductpropers")]
    partial class addProductpropers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("SimCard.API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BuyingPrice");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Quantity");

                    b.Property<int>("ShopId");

                    b.Property<string>("Unit");

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
                    b.HasOne("SimCard.API.Models.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}