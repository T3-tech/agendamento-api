using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendamento_api.Migrations
{
    /// <inheritdoc />
    public partial class teste4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "profissinalId",
                table: "Servicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profissinalId",
                table: "Servicos");
        }
    }
}
