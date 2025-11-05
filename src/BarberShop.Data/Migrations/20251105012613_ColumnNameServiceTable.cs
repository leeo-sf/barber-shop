using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNameServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Service",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Service",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Service",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Service",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Service",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Service",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Service",
                newName: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Service",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Service",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Service",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Service",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Service",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Service",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Service",
                newName: "CreatedAt");
        }
    }
}
