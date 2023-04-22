using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeAhorroYPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class Omard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdCuentaBanco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "CuentaBancos",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteCedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaBancos", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_CuentaBancos_Clientes_ClienteCedula",
                        column: x => x.ClienteCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    FechaBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    ClienteCedula = table.Column<string>(type: "nvarchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_ClienteCedula",
                        column: x => x.ClienteCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inversiones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    FechaBeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentaBancoNumero = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    ClienteCedula = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inversiones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Inversiones_Clientes_ClienteCedula",
                        column: x => x.ClienteCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inversiones_CuentaBancos_CuentaBancoNumero",
                        column: x => x.CuentaBancoNumero,
                        principalTable: "CuentaBancos",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CuotaPrestamos",
                columns: table => new
                {
                    PrestamoCodigo = table.Column<int>(type: "int", nullable: false),
                    FechaPlanificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRealizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoComprobante = table.Column<int>(type: "int", nullable: false),
                    ClienteCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestamoCodigoNavigationCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotaPrestamos", x => x.PrestamoCodigo);
                    table.ForeignKey(
                        name: "FK_CuotaPrestamos_Prestamos_PrestamoCodigoNavigationCodigo",
                        column: x => x.PrestamoCodigoNavigationCodigo,
                        principalTable: "Prestamos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garantias",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestamoCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantias", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Garantias_Prestamos_PrestamoCodigo",
                        column: x => x.PrestamoCodigo,
                        principalTable: "Prestamos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotaInversiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FechaPlanificada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRealizada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoComprobante = table.Column<int>(type: "int", nullable: false),
                    CuentaBancoNumero = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    CodigoInversion = table.Column<int>(type: "int", nullable: false),
                    CodigoInversionNavigationCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotaInversiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuotaInversiones_CuentaBancos_CuentaBancoNumero",
                        column: x => x.CuentaBancoNumero,
                        principalTable: "CuentaBancos",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuotaInversiones_Inversiones_CodigoInversionNavigationCodigo",
                        column: x => x.CodigoInversionNavigationCodigo,
                        principalTable: "Inversiones",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaBancos_ClienteCedula",
                table: "CuentaBancos",
                column: "ClienteCedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuotaInversiones_CodigoInversionNavigationCodigo",
                table: "CuotaInversiones",
                column: "CodigoInversionNavigationCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_CuotaInversiones_CuentaBancoNumero",
                table: "CuotaInversiones",
                column: "CuentaBancoNumero");

            migrationBuilder.CreateIndex(
                name: "IX_CuotaPrestamos_PrestamoCodigoNavigationCodigo",
                table: "CuotaPrestamos",
                column: "PrestamoCodigoNavigationCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Garantias_PrestamoCodigo",
                table: "Garantias",
                column: "PrestamoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inversiones_ClienteCedula",
                table: "Inversiones",
                column: "ClienteCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Inversiones_CuentaBancoNumero",
                table: "Inversiones",
                column: "CuentaBancoNumero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteCedula",
                table: "Prestamos",
                column: "ClienteCedula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuotaInversiones");

            migrationBuilder.DropTable(
                name: "CuotaPrestamos");

            migrationBuilder.DropTable(
                name: "Garantias");

            migrationBuilder.DropTable(
                name: "Inversiones");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "CuentaBancos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
