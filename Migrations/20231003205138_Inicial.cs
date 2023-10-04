using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBMVCTrabalho2.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria_Gastos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_Gastos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Conta_Bancaria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bancosID = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Saldo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta_Bancaria", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conta_Bancaria_Bancos_bancosID",
                        column: x => x.bancosID,
                        principalTable: "Bancos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_Bancaria_bancosID",
                table: "Conta_Bancaria",
                column: "bancosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria_Gastos");

            migrationBuilder.DropTable(
                name: "Conta_Bancaria");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
