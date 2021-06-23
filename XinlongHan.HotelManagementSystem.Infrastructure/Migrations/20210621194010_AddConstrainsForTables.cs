using Microsoft.EntityFrameworkCore.Migrations;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Migrations
{
    public partial class AddConstrainsForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rooms_RoomId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomtypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServices_Rooms_RoomId",
                table: "RoomServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomServices",
                table: "RoomServices");

            migrationBuilder.DropIndex(
                name: "IX_RoomServices_RoomId",
                table: "RoomServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomtypeId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RoomId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomServices");

            migrationBuilder.DropColumn(
                name: "RoomtypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                newName: "RoomType");

            migrationBuilder.RenameTable(
                name: "RoomServices",
                newName: "RoomService");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "RoomType",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "RTDesc",
                table: "RoomType",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SDesc",
                table: "RoomService",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "RoomService",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CName",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Advance",
                table: "Customer",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomService",
                table: "RoomService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_RoomNo",
                table: "RoomService",
                column: "RoomNo");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RTCode",
                table: "Room",
                column: "RTCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RoomNo",
                table: "Customer",
                column: "RoomNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Room_RoomNo",
                table: "Customer",
                column: "RoomNo",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RTCode",
                table: "Room",
                column: "RTCode",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomService_Room_RoomNo",
                table: "RoomService",
                column: "RoomNo",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Room_RoomNo",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RTCode",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomService_Room_RoomNo",
                table: "RoomService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomService",
                table: "RoomService");

            migrationBuilder.DropIndex(
                name: "IX_RoomService_RoomNo",
                table: "RoomService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RTCode",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_RoomNo",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "RoomType",
                newName: "RoomTypes");

            migrationBuilder.RenameTable(
                name: "RoomService",
                newName: "RoomServices");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "RoomTypes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "RTDesc",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SDesc",
                table: "RoomServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "RoomServices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomtypeId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Advance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomServices",
                table: "RoomServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServices_RoomId",
                table: "RoomServices",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomtypeId",
                table: "Rooms",
                column: "RoomtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RoomId",
                table: "Customers",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Rooms_RoomId",
                table: "Customers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomtypeId",
                table: "Rooms",
                column: "RoomtypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServices_Rooms_RoomId",
                table: "RoomServices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
