using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudSprint2.Migrations
{
    /// <inheritdoc />
    public partial class initialAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agendamentos",
                columns: table => new
                {
                    N_protocolo = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Data_hora_agendamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Unidade_id_unidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Paciente_cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamentos", x => x.N_protocolo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentos");
        }
    }
}
