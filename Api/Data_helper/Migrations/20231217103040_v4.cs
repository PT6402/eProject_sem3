using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data_helper.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_Address",
                table: "tbTP_contractor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Address",
                table: "tbUser");

            migrationBuilder.DropIndex(
                name: "IX_tbUser_Addresses_Id",
                table: "tbUser");

            migrationBuilder.DropIndex(
                name: "IX_tbTP_contractor_Addresses_Id",
                table: "tbTP_contractor");

            migrationBuilder.DropIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders");

            migrationBuilder.DropColumn(
                name: "Addresses_Id",
                table: "tbUser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tbTP_contractor");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "tbTP_contractor");

            migrationBuilder.AlterColumn<int>(
                name: "Addresses_Id",
                table: "tbTP_contractor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "tbTP_contractor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbTP_contractor_Addresses_Id",
                table: "tbTP_contractor",
                column: "Addresses_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbTP_contractor_User_Id",
                table: "tbTP_contractor",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders",
                column: "TP_contractor_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_Address",
                table: "tbTP_contractor",
                column: "Addresses_Id",
                principalTable: "tbAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_User",
                table: "tbTP_contractor",
                column: "User_Id",
                principalTable: "tbUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_Address",
                table: "tbTP_contractor");

            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_User",
                table: "tbTP_contractor");

            migrationBuilder.DropIndex(
                name: "IX_tbTP_contractor_Addresses_Id",
                table: "tbTP_contractor");

            migrationBuilder.DropIndex(
                name: "IX_tbTP_contractor_User_Id",
                table: "tbTP_contractor");

            migrationBuilder.DropIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "tbTP_contractor");

            migrationBuilder.AddColumn<int>(
                name: "Addresses_Id",
                table: "tbUser",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Addresses_Id",
                table: "tbTP_contractor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tbTP_contractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "tbTP_contractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbUser_Addresses_Id",
                table: "tbUser",
                column: "Addresses_Id",
                unique: true,
                filter: "[Addresses_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbTP_contractor_Addresses_Id",
                table: "tbTP_contractor",
                column: "Addresses_Id",
                unique: true,
                filter: "[Addresses_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders",
                column: "TP_contractor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_Address",
                table: "tbTP_contractor",
                column: "Addresses_Id",
                principalTable: "tbAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address",
                table: "tbUser",
                column: "Addresses_Id",
                principalTable: "tbAddress",
                principalColumn: "Id");
        }
    }
}
