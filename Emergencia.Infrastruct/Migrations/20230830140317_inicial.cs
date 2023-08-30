using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emergencia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NmCliente = table.Column<string>(type: "text", nullable: true),
                    NrCpf = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_cliente_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_evento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    flAtivo = table.Column<bool>(type: "boolean", nullable: false),
                    vlEvento = table.Column<decimal>(type: "numeric", nullable: true),
                    nmEvento = table.Column<string>(type: "text", nullable: true),
                    dtEvento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_evento_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    vlPagamento = table.Column<decimal>(type: "numeric", nullable: true),
                    QtdParcelas = table.Column<int>(type: "integer", nullable: true),
                    CdCliente = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_pagamento_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tb_pagamento_tb_cliente_1",
                        column: x => x.CdCliente,
                        principalTable: "tb_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_inscricao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nrChave = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true, defaultValue: "Aguardadndo pagamento"),
                    dtInsricao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CdCliente = table.Column<Guid>(type: "uuid", nullable: false),
                    CdEvento = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_inscricao_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "fk_evento_inscricao",
                        column: x => x.CdEvento,
                        principalTable: "tb_evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inscricao_tb_cliente_1",
                        column: x => x.CdCliente,
                        principalTable: "tb_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscricao_CdCliente",
                table: "tb_inscricao",
                column: "CdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscricao_CdEvento",
                table: "tb_inscricao",
                column: "CdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pagamento_CdCliente",
                table: "tb_pagamento",
                column: "CdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_inscricao");

            migrationBuilder.DropTable(
                name: "tb_pagamento");

            migrationBuilder.DropTable(
                name: "tb_evento");

            migrationBuilder.DropTable(
                name: "tb_cliente");
        }
    }
}
