using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data_helper.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProduct_tbConnect_type_Connect_type_IdId",
                table: "tbProduct");

            migrationBuilder.RenameColumn(
                name: "Connect_type_IdId",
                table: "tbProduct",
                newName: "Connect_type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_tbProduct_Connect_type_IdId",
                table: "tbProduct",
                newName: "IX_tbProduct_Connect_type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ConnectType",
                table: "tbProduct",
                column: "Connect_type_Id",
                principalTable: "tbConnect_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ConnectType",
                table: "tbProduct");

            migrationBuilder.RenameColumn(
                name: "Connect_type_Id",
                table: "tbProduct",
                newName: "Connect_type_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_tbProduct_Connect_type_Id",
                table: "tbProduct",
                newName: "IX_tbProduct_Connect_type_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduct_tbConnect_type_Connect_type_IdId",
                table: "tbProduct",
                column: "Connect_type_IdId",
                principalTable: "tbConnect_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
