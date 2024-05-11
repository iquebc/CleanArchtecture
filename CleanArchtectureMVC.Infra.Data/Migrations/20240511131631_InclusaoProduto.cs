using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchtectureMVC.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Stock" },
                values: new object[] { 1, 1, "Test Description Product", "", "Test Product", 10m, 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
