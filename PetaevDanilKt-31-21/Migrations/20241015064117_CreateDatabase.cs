using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetaevDanilKt_31_21.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    disciplineName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Название предмета"),
                    isHumanities = table.Column<bool>(type: "bool", nullable: false, comment: "Гуманитарное направление"),
                    isTechnical = table.Column<bool>(type: "bool", nullable: false, comment: "Техническое направление"),
                    isDeleted = table.Column<bool>(type: "bool", nullable: false, comment: "Удален ли предмет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Discipline_discipline_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Название группы"),
                    speciality = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Специальность группы"),
                    startYear = table.Column<int>(type: "int4", nullable: false, comment: "Год начала обучения"),
                    yearGraduation = table.Column<int>(type: "int4", nullable: false, comment: "Год выпуска"),
                    isDeleted = table.Column<bool>(type: "bool", nullable: false, comment: "Удалена ли группа")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Group_group_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Имя студента"),
                    lastName = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Фамилия студента"),
                    middleName = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Отчество студента"),
                    groupId = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы"),
                    isDeleted = table.Column<bool>(type: "bool", nullable: false, comment: "Удален ли пользователь")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Student_student_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_Student_group",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    score = table.Column<int>(type: "int4", nullable: false, comment: "Оценка"),
                    studentId = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента"),
                    disciplineId = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Grade_grade_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_Grade_Disciplines_disciplineId",
                        column: x => x.disciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isPassed = table.Column<bool>(type: "bool", nullable: false, comment: "Зачет сдан/не сдан"),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Test_test_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_Test_discipline",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Test_student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ind_Grade_fk_discipline_id",
                table: "Grade",
                column: "disciplineId");

            migrationBuilder.CreateIndex(
                name: "ind_Grade_fk_student_id",
                table: "Grade",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "ind_Student_fk_group_id",
                table: "Student",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "ind_Test_fk_discipline_id",
                table: "Test",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "ind_Test_fk_student_id",
                table: "Test",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
