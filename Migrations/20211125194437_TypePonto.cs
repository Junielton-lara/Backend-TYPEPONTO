using Microsoft.EntityFrameworkCore.Migrations;

namespace TypePonto.Migrations
{
    public partial class TypePonto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorHora = table.Column<double>(type: "float", nullable: false),
                    DataAdm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabFuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabMarcacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DataMarcacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraSaidaAlmoco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraVoltaAlmoco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horasT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabMarcacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabMarcacoes_TabFuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TabFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabMarcacoes_FuncionarioId",
                table: "TabMarcacoes",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabMarcacoes");

            migrationBuilder.DropTable(
                name: "TabFuncionarios");
        }
    }
}
