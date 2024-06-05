using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRH.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: true),
                    RG = table.Column<string>(type: "TEXT", nullable: true),
                    DataInicioContratoDeTrabalho = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFimContratoDeTrabalho = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Salario = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holerites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColaboradorId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalDosVencimentos = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDosDescontos = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holerites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holerites_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DestinatarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    Mensagem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Colaboradores_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColaboradorId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataMarcacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pontos_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    FaixaSalarialMin = table.Column<decimal>(type: "TEXT", nullable: false),
                    FaixaSalarialMax = table.Column<decimal>(type: "TEXT", nullable: false),
                    Aberta = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true),
                    AbertaPorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagas_Colaboradores_AbertaPorId",
                        column: x => x.AbertaPorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LancamentoHolerite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Referencia = table.Column<string>(type: "TEXT", nullable: true),
                    HoleriteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoHolerite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoHolerite_Holerites_HoleriteId",
                        column: x => x.HoleriteId,
                        principalTable: "Holerites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: true),
                    RG = table.Column<string>(type: "TEXT", nullable: true),
                    SalarioPretendido = table.Column<decimal>(type: "TEXT", nullable: false),
                    Aprovado = table.Column<bool>(type: "INTEGER", nullable: false),
                    VagaAplicadaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Vagas_VagaAplicadaId",
                        column: x => x.VagaAplicadaId,
                        principalTable: "Vagas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_VagaAplicadaId",
                table: "Candidatos",
                column: "VagaAplicadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Holerites_ColaboradorId",
                table: "Holerites",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHolerite_HoleriteId",
                table: "LancamentoHolerite",
                column: "HoleriteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_DestinatarioId",
                table: "Notificacoes",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pontos_ColaboradorId",
                table: "Pontos",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_AbertaPorId",
                table: "Vagas",
                column: "AbertaPorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "LancamentoHolerite");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "Pontos");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Holerites");

            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
