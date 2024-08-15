using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCLions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AtaTitulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    AtaDescricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoComissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDespesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDespesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataVencimento = table.Column<string>(type: "date", nullable: false),
                    DataRegistro = table.Column<string>(type: "date", nullable: false),
                    ValorTotal = table.Column<double>(type: "decimal(8,2)", nullable: false),
                    IdMembro = table.Column<Guid>(type: "text", nullable: false),
                    MembroId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdTipoComissao = table.Column<Guid>(type: "text", nullable: false),
                    TipoComissaoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comissao_TipoComissao_TipoComissaoId",
                        column: x => x.TipoComissaoId,
                        principalTable: "TipoComissao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Despesa e Tipo Despesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdDespesa = table.Column<Guid>(type: "text", nullable: false),
                    DespesaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdTipoDespesa = table.Column<Guid>(type: "text", nullable: false),
                    TipoDespesaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ValorDespesa = table.Column<double>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa e Tipo Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa e Tipo Despesa_Despesa_DespesaId",
                        column: x => x.DespesaId,
                        principalTable: "Despesa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Despesa e Tipo Despesa_TipoDespesa_TipoDespesaId",
                        column: x => x.TipoDespesaId,
                        principalTable: "TipoDespesa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Membro e Comissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdMembro = table.Column<Guid>(type: "text", nullable: false),
                    MembroId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdComissao = table.Column<Guid>(type: "text", nullable: false),
                    ComissaoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DataInicio = table.Column<string>(type: "date", nullable: false),
                    DataFim = table.Column<string>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro e Comissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membro e Comissao_Comissao_ComissaoId",
                        column: x => x.ComissaoId,
                        principalTable: "Comissao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Membro e Comissao_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comissao_TipoComissaoId",
                table: "Comissao",
                column: "TipoComissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_MembroId",
                table: "Despesa",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa e Tipo Despesa_DespesaId",
                table: "Despesa e Tipo Despesa",
                column: "DespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa e Tipo Despesa_TipoDespesaId",
                table: "Despesa e Tipo Despesa",
                column: "TipoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro e Comissao_ComissaoId",
                table: "Membro e Comissao",
                column: "ComissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro e Comissao_MembroId",
                table: "Membro e Comissao",
                column: "MembroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ata");

            migrationBuilder.DropTable(
                name: "Despesa e Tipo Despesa");

            migrationBuilder.DropTable(
                name: "Membro e Comissao");

            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "TipoDespesa");

            migrationBuilder.DropTable(
                name: "Comissao");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "TipoComissao");
        }
    }
}
