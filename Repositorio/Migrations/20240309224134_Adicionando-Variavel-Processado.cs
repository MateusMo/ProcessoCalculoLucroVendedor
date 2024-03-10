using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoVariavelProcessado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Matricula = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Sexo = table.Column<short>(type: "smallint", nullable: false),
                    ClassVendedor = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lucro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "Float", nullable: false),
                    MeioPagamentoEnum = table.Column<short>(type: "smallint", nullable: false),
                    DataLucro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lucro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lucro_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "Float", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "DateTime", nullable: false),
                    MeioPagamento = table.Column<short>(type: "smallint", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    Processado = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Vendedor",
                columns: new[] { "Id", "ClassVendedor", "Email", "Matricula", "Name", "Sexo" },
                values: new object[,]
                {
                    { 2, (short)1, "vendedor1@dominio.com", 12345678, "Vendedor1", (short)0 },
                    { 3, (short)1, "vendedor2@dominio.com", 12345678, "Vendedor2", (short)1 },
                    { 4, (short)1, "vendedor3@dominio.com", 12345678, "Vendedor3", (short)0 },
                    { 5, (short)2, "vendedor4@dominio.com", 12345678, "Vendedor4", (short)1 },
                    { 6, (short)1, "vendedor5@dominio.com", 12345678, "Vendedor5", (short)0 },
                    { 7, (short)2, "vendedor6@dominio.com", 12345678, "Vendedor6", (short)1 },
                    { 8, (short)1, "vendedor7@dominio.com", 12345678, "Vendedor7", (short)0 },
                    { 9, (short)2, "vendedor8@dominio.com", 12345678, "Vendedor8", (short)1 },
                    { 10, (short)2, "vendedor9@dominio.com", 12345678, "Vendedor9", (short)0 },
                    { 11, (short)2, "vendedor10@dominio.com", 12345678, "Vendedor10", (short)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lucro_VendedorId",
                table: "Lucro",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VendedorId",
                table: "Venda",
                column: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lucro");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
