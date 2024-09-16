using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudSprint2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Nome_completo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_nasc = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    End_paciente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tel_paciente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email_paciente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.Cpf);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pacientes");
        }
    }
}
