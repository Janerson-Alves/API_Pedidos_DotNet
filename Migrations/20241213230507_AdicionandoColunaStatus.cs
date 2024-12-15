using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedidos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Pedidos");
        }
    }
}
