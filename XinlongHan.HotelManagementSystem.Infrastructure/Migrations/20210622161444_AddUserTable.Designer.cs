﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XinlongHan.HotelManagementSystem.Infrastructure.Data;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    [Migration("20210622161444_AddUserTable")]
    partial class AddUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Advance")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("BookingDays")
                        .HasColumnType("int");

                    b.Property<string>("CName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Checkin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RoomNo")
                        .HasColumnType("int");

                    b.Property<int>("TotalPersons")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomNo");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RTCode")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("RTCode");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.RoomService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("RoomNo")
                        .HasColumnType("int");

                    b.Property<string>("SDesc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomNo");

                    b.ToTable("RoomService");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RTDesc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Rent")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("HashedPassword")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Salt")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.Customer", b =>
                {
                    b.HasOne("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.Room", "Room")
                        .WithMany("Customers")
                        .HasForeignKey("RoomNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.Room", b =>
                {
                    b.HasOne("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.RoomType", "Roomtype")
                        .WithMany("Rooms")
                        .HasForeignKey("RTCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roomtype");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.RoomService", b =>
                {
                    b.HasOne("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.Room", "Room")
                        .WithMany("Roomservices")
                        .HasForeignKey("RoomNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.Room", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Roomservices");
                });

            modelBuilder.Entity("XinlongHan.HotelManagementSystem.ApplicationCore.Entities.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
