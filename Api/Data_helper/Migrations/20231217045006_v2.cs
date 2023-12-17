using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data_helper.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbTP_contractor_Addresses_Id",
                table: "tbTP_contractor");

            migrationBuilder.DropIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders");

            migrationBuilder.DropIndex(
                name: "IX_tbAddress_store_Addresses_Id",
                table: "tbAddress_store");

            migrationBuilder.AddColumn<int>(
                name: "Numb_Connect",
                table: "tbProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Numb_Connect",
                table: "tbOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_tbAddress_store_Addresses_Id",
                table: "tbAddress_store",
                column: "Addresses_Id",
                unique: true,
                filter: "[Addresses_Id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbTP_contractor_Addresses_Id",
                table: "tbTP_contractor");

            migrationBuilder.DropIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders");

            migrationBuilder.DropIndex(
                name: "IX_tbAddress_store_Addresses_Id",
                table: "tbAddress_store");

            migrationBuilder.DropColumn(
                name: "Numb_Connect",
                table: "tbProduct");

            migrationBuilder.DropColumn(
                name: "Numb_Connect",
                table: "tbOrders");

            migrationBuilder.CreateIndex(
                name: "IX_tbTP_contractor_Addresses_Id",
                table: "tbTP_contractor",
                column: "Addresses_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrders_TP_contractor_Id",
                table: "tbOrders",
                column: "TP_contractor_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbAddress_store_Addresses_Id",
                table: "tbAddress_store",
                column: "Addresses_Id");
        }
    }
}
