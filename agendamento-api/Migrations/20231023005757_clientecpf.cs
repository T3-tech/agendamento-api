using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendamento_api.Migrations
{
    /// <inheritdoc />
    public partial class clientecpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Clientes_ClientesId",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "ClientesId",
                table: "Agendamentos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_ClientesId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Clientes_ClienteId",
                table: "Agendamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Clientes_ClienteId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Agendamentos",
                newName: "ClientesId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_ClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Clientes_ClientesId",
                table: "Agendamentos",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
