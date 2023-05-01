using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class Criacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALUNO",
                columns: table => new
                {
                    ALN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALN_CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALN_NOME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNO", x => x.ALN_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TURMA",
                columns: table => new
                {
                    TRM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRM_NUMERO = table.Column<int>(type: "int", nullable: false),
                    TRM_ANO_LETIVO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TURMA", x => x.TRM_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALUNO_TURMA",
                columns: table => new
                {
                    ALT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALN_ID = table.Column<int>(type: "int", nullable: false),
                    TRM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNO_TURMA", x => x.ALT_ID);
                    table.ForeignKey(
                        name: "FK_TB_ALUNO_TURMA_TB_ALUNO_ALN_ID",
                        column: x => x.ALN_ID,
                        principalTable: "TB_ALUNO",
                        principalColumn: "ALN_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ALUNO_TURMA_TB_TURMA_TRM_ID",
                        column: x => x.TRM_ID,
                        principalTable: "TB_TURMA",
                        principalColumn: "TRM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_TURMA_ALN_ID",
                table: "TB_ALUNO_TURMA",
                column: "ALN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_TURMA_TRM_ID",
                table: "TB_ALUNO_TURMA",
                column: "TRM_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALUNO_TURMA");

            migrationBuilder.DropTable(
                name: "TB_ALUNO");

            migrationBuilder.DropTable(
                name: "TB_TURMA");
        }
    }
}
