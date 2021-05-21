using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndClass.Migrations
{
    public partial class RelationFor_OthersEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoServicio",
                table: "Servicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoServicioid",
                table: "Servicio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMestroProveedor",
                table: "Proveedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaestroProveedorId",
                table: "Proveedor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdArticulo",
                table: "Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoArticuloid",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaestroProveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestroProveedor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_TipoServicioid",
                table: "Servicio",
                column: "TipoServicioid");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_MaestroProveedorId",
                table: "Proveedor",
                column: "MaestroProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_TipoArticuloid",
                table: "Articulo",
                column: "TipoArticuloid");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_TipoArticulo_TipoArticuloid",
                table: "Articulo",
                column: "TipoArticuloid",
                principalTable: "TipoArticulo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_MaestroProveedor_MaestroProveedorId",
                table: "Proveedor",
                column: "MaestroProveedorId",
                principalTable: "MaestroProveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_TipoServicio_TipoServicioid",
                table: "Servicio",
                column: "TipoServicioid",
                principalTable: "TipoServicio",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_TipoArticulo_TipoArticuloid",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_MaestroProveedor_MaestroProveedorId",
                table: "Proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_TipoServicio_TipoServicioid",
                table: "Servicio");

            migrationBuilder.DropTable(
                name: "MaestroProveedor");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_TipoServicioid",
                table: "Servicio");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_MaestroProveedorId",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_TipoArticuloid",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "IdTipoServicio",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "TipoServicioid",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "IdMestroProveedor",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "MaestroProveedorId",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "IdArticulo",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "TipoArticuloid",
                table: "Articulo");
        }
    }
}
