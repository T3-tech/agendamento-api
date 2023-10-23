using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendamento_api.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoRelacionamentosDasModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "Agendamentos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idServico",
                table: "Agendamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ProfissionalId",
                table: "Agendamentos",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Profissionais_ProfissionalId",
                table: "Agendamentos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Profissionais_ProfissionalId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ProfissionalId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "idServico",
                table: "Agendamentos");
        }
    }
}
