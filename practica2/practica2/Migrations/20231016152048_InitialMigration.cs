using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace practica2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "universidad",
                columns: table => new
                {
                    Id_uni = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universidad", x => x.Id_uni);
                });

            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    Id_Doce = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    Sexo = table.Column<bool>(type: "boolean", nullable: false),
                    Ci = table.Column<string>(type: "text", nullable: false),
                    Id_uni = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.Id_Doce);
                    table.ForeignKey(
                        name: "FK_docentes_universidad_Id_uni",
                        column: x => x.Id_uni,
                        principalTable: "universidad",
                        principalColumn: "Id_uni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    Id_estu = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Sexo = table.Column<bool>(type: "boolean", nullable: false),
                    Id_uni = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.Id_estu);
                    table.ForeignKey(
                        name: "FK_estudiantes_universidad_Id_uni",
                        column: x => x.Id_uni,
                        principalTable: "universidad",
                        principalColumn: "Id_uni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    Id_Materia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Id_Doce = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.Id_Materia);
                    table.ForeignKey(
                        name: "FK_materias_docentes_Id_Doce",
                        column: x => x.Id_Doce,
                        principalTable: "docentes",
                        principalColumn: "Id_Doce",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_docentes_Id_uni",
                table: "docentes",
                column: "Id_uni");

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_Id_uni",
                table: "estudiantes",
                column: "Id_uni");

            migrationBuilder.CreateIndex(
                name: "IX_materias_Id_Doce",
                table: "materias",
                column: "Id_Doce");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "docentes");

            migrationBuilder.DropTable(
                name: "universidad");
        }
    }
}
