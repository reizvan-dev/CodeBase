using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddataproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "14 inc, CORE 7, 8 GB RAM, 2TB SSD", "Lenovo Thinkpad T1456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
