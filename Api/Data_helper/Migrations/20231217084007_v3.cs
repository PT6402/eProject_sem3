using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data_helper.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Address",
                table: "tbAddress_store");

            migrationBuilder.DropIndex(
                name: "IX_tbOrders_Coupon_Id",
                table: "tbOrders");

            migrationBuilder.DropIndex(
                name: "IX_tbAddress_store_Addresses_Id",
                table: "tbAddress_store");

            migrationBuilder.DropColumn(
                name: "Addresses_Id",
                table: "tbAddress_store");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "tbEmployee",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_tbEmployee_UserId",
                table: "tbEmployee",
                newName: "IX_tbEmployee_User_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Coupon_Id",
                table: "tbOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Region_code",
                table: "tbAddress_store",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region_name",
                table: "tbAddress_store",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Order_handler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address_store_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: true),
                    StatusHandle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_handler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_handle_Address_store",
                        column: x => x.Address_store_Id,
                        principalTable: "tbAddress_store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_handle_Employee",
                        column: x => x.Employee_Id,
                        principalTable: "tbEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_handle_Order",
                        column: x => x.Order_Id,
                        principalTable: "tbOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_Coupon_Id",
                table: "tbOrders",
                column: "Coupon_Id",
                unique: true,
                filter: "[Coupon_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_handler_Address_store_Id",
                table: "Order_handler",
                column: "Address_store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_handler_Employee_Id",
                table: "Order_handler",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_handler_Order_Id",
                table: "Order_handler",
                column: "Order_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_handler");

            migrationBuilder.DropIndex(
                name: "IX_tbOrders_Coupon_Id",
                table: "tbOrders");

            migrationBuilder.DropColumn(
                name: "Region_code",
                table: "tbAddress_store");

            migrationBuilder.DropColumn(
                name: "Region_name",
                table: "tbAddress_store");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "tbEmployee",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbEmployee_User_Id",
                table: "tbEmployee",
                newName: "IX_tbEmployee_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Coupon_Id",
                table: "tbOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Addresses_Id",
                table: "tbAddress_store",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_Coupon_Id",
                table: "tbOrders",
                column: "Coupon_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbAddress_store_Addresses_Id",
                table: "tbAddress_store",
                column: "Addresses_Id",
                unique: true,
                filter: "[Addresses_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Address",
                table: "tbAddress_store",
                column: "Addresses_Id",
                principalTable: "tbAddress",
                principalColumn: "Id");
        }
    }
}
