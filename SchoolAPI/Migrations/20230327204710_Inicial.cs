using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Street = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ra = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", maxLength: 255, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "varchar(max)", maxLength: 255, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatterProfessor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatterId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterProfessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatterProfessor_Matter_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatterProfessor_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grades1 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Grades2 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Grades3 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Grades4 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MatterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Matter_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_MatterId",
                table: "Grade",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId",
                table: "Grade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterProfessor_MatterId",
                table: "MatterProfessor",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterProfessor_ProfessorId",
                table: "MatterProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                table: "Student",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "MatterProfessor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Matter");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
