using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudSprint2.Migrations
{
    /// <inheritdoc />
    public partial class initialUnidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unidades",
                columns: table => new
                {
                    Id_unidade = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    End_unidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo_exame = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Atende_convenio = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    Clinica_cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidades", x => x.Id_unidade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unidades");
        }
    }
}
