using Microsoft.EntityFrameworkCore.Migrations;

namespace Briefing.Infrastructure.Data.Migrations
{
    public partial class ajusteResposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPergunta",
                schema: "socialmente",
                table: "Resposta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPergunta",
                schema: "socialmente",
                table: "Resposta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
