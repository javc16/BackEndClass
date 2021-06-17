using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndClass.Migrations
{
    public partial class ProveedorImagen2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Proveedor",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Proveedor");
        }
    }
}
