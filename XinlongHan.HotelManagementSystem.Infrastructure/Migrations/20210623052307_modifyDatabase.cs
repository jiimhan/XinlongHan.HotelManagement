using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class modifyDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomService_Room_RoomNo",
                table: "RoomService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomService",
                table: "RoomService");

            migrationBuilder.RenameTable(
                name: "RoomService",
                newName: "Roomservice");

            migrationBuilder.RenameIndex(
                name: "IX_RoomService_RoomNo",
                table: "Roomservice",
                newName: "IX_Roomservice_RoomNo");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "RoomType",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ServiceDate",
                table: "Roomservice",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "RoomNo",
                table: "Roomservice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Roomservice",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPersons",
                table: "Customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookingDays",
                table: "Customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roomservice",
                table: "Roomservice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roomservice_Room_RoomNo",
                table: "Roomservice",
                column: "RoomNo",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roomservice_Room_RoomNo",
                table: "Roomservice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roomservice",
                table: "Roomservice");

            migrationBuilder.RenameTable(
                name: "Roomservice",
                newName: "RoomService");

            migrationBuilder.RenameIndex(
                name: "IX_Roomservice_RoomNo",
                table: "RoomService",
                newName: "IX_RoomService_RoomNo");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "RoomType",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ServiceDate",
                table: "RoomService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomNo",
                table: "RoomService",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "RoomService",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalPersons",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookingDays",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomService",
                table: "RoomService",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomService_Room_RoomNo",
                table: "RoomService",
                column: "RoomNo",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
