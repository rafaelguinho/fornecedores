using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    TipoPessoa = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    IdEmpresa = table.Column<int>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    FornecedorPessoaJuridica_IdEmpresa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Pessoas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Pessoas_FornecedorPessoaJuridica_IdEmpresa",
                        column: x => x.FornecedorPessoaJuridica_IdEmpresa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_IdEmpresa",
                table: "Pessoas",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_FornecedorPessoaJuridica_IdEmpresa",
                table: "Pessoas",
                column: "FornecedorPessoaJuridica_IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PessoaId",
                table: "Telefone",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
