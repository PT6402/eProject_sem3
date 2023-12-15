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
            migrationBuilder.RenameColumn(
                name: "ResetTokenExpires",
                table: "tbUser",
                newName: "ResetExpires");

            migrationBuilder.RenameColumn(
                name: "PasswordResetToken",
                table: "tbUser",
                newName: "PasswordReset");

            migrationBuilder.AddColumn<int>(
                name: "MethodReset",
                table: "tbUser",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MethodReset",
                table: "tbUser");

            migrationBuilder.RenameColumn(
                name: "ResetExpires",
                table: "tbUser",
                newName: "ResetTokenExpires");

            migrationBuilder.RenameColumn(
                name: "PasswordReset",
                table: "tbUser",
                newName: "PasswordResetToken");
        }
    }
}
