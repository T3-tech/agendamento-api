using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendamento_api.Migrations
{
    /// <inheritdoc />
    public partial class ajustesTecnicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Servicos_ServicosId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ServicosId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ServicosId",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "idServico",
                table: "Agendamentos",
                newName: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "ServicoId",
                table: "Agendamentos",
                newName: "idServico");

            migrationBuilder.AddColumn<int>(
                name: "ServicosId",
                table: "Agendamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicosId",
                table: "Agendamentos",
                column: "ServicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Servicos_ServicosId",
                table: "Agendamentos",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
