using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Briefing.Infrastructure.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "socialmente");

            migrationBuilder.CreateTable(
                name: "Pergunta",
                schema: "socialmente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Display = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                schema: "socialmente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPergunta = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(type: "Varchar(100)", nullable: false),
                    PerguntaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resposta_Pergunta_PerguntaId",
                        column: x => x.PerguntaId,
                        principalSchema: "socialmente",
                        principalTable: "Pergunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_PerguntaId",
                schema: "socialmente",
                table: "Resposta",
                column: "PerguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resposta",
                schema: "socialmente");

            migrationBuilder.DropTable(
                name: "Pergunta",
                schema: "socialmente");
        }
    }
}
