using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedidos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaStatusCorretamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Pedidos",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pedidos",
                newName: "status");
        }
    }
}
