using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(ConfigureCustomer);
            modelBuilder.Entity<Room>(ConfigureRoom);
            modelBuilder.Entity<RoomType>(ConfigureRoomtype);
            modelBuilder.Entity<Roomservice>(ConfigureRoomservice);
            modelBuilder.Entity<User>(ConfigureUser);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Roomservice> RoomServices { get; set; }
        public DbSet<User> Users { get; set; }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.CName).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(40);
            builder.Property(c => c.Advance).HasColumnType("decimal(8, 2)");
            builder.HasOne(r => r.Room).WithMany(c => c.Customers).HasForeignKey(c => c.RoomNo);
        }

        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.HasOne(r => r.Roomtype).WithMany(rt => rt.Rooms).HasForeignKey(r => r.RTCode);
        }

        private void ConfigureRoomservice(EntityTypeBuilder<Roomservice> builder)
        {
            builder.ToTable("Roomservice");
            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Id).ValueGeneratedOnAdd();
            builder.HasOne(r => r.Room).WithMany(rs => rs.Roomservices).HasForeignKey(rs => rs.RoomNo);
            builder.Property(rs => rs.SDesc).HasMaxLength(50);
            builder.Property(c => c.Amount).HasColumnType("decimal(5, 2)");
        }

        private void ConfigureRoomtype(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("RoomType");
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id).ValueGeneratedOnAdd();
            builder.Property(rt => rt.RTDesc).HasMaxLength(20);
            builder.Property(rt => rt.Rent).HasColumnType("decimal(5, 2)");
        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
        }
    }
}
