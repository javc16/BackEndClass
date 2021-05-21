using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndClass.Migrations
{
    public partial class RelationFor_Recomendacion_WithProveedor_and_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProveedor",
                table: "Recomendacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Recomendacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Recomendacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Recomendacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recomendacion_ProveedorId",
                table: "Recomendacion",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendacion_UsuarioId",
                table: "Recomendacion",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendacion_Proveedor_ProveedorId",
                table: "Recomendacion",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendacion_Usuario_UsuarioId",
                table: "Recomendacion",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recomendacion_Proveedor_ProveedorId",
                table: "Recomendacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendacion_Usuario_UsuarioId",
                table: "Recomendacion");

            migrationBuilder.DropIndex(
                name: "IX_Recomendacion_ProveedorId",
                table: "Recomendacion");

            migrationBuilder.DropIndex(
                name: "IX_Recomendacion_UsuarioId",
                table: "Recomendacion");

            migrationBuilder.DropColumn(
                name: "IdProveedor",
                table: "Recomendacion");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Recomendacion");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Recomendacion");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Recomendacion");
        }
    }
}
