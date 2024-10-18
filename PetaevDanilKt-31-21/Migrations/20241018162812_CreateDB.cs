using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetaevDanilKt_31_21.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Название предмета"),
                    c_discipline_is_humanities = table.Column<bool>(type: "bool", nullable: false, comment: "Гуманитарное направление"),
                    c_discipline_is_technical = table.Column<bool>(type: "bool", nullable: false, comment: "Техническое направление"),
                    c_is_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Удален ли предмет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_name = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Название группы"),
                    c_group_speciality = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Специальность группы"),
                    c_group_start_year = table.Column<int>(type: "int4", nullable: false, comment: "Год начала обучения"),
                    c_group_year_graduation = table.Column<int>(type: "int4", nullable: false, comment: "Год выпуска"),
                    c_is_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Удалена ли группа")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "varchar", maxLength: 25, nullable: false, comment: "Отчество студента"),
                    c_student_group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы"),
                    c_is_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Удален ли пользователь")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.c_student_group_id,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_grade_score = table.Column<int>(type: "int4", nullable: false, comment: "Оценка"),
                    c_grade_student_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента"),
                    c_grade_discipline_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_grade_grade_id", x => x.grade_id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.c_grade_discipline_id,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.c_grade_student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_test",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_test_is_passed = table.Column<bool>(type: "bool", nullable: false, comment: "Зачет сдан/не сдан"),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_test_test_id", x => x.test_id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.StudentId,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ind_cd_grade_fk_f_discipline_id",
                table: "cd_grade",
                column: "c_grade_discipline_id");

            migrationBuilder.CreateIndex(
                name: "ind_cd_grade_fk_student_id",
                table: "cd_grade",
                column: "c_grade_student_id");

            migrationBuilder.CreateIndex(
                name: "ind_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "c_student_group_id");

            migrationBuilder.CreateIndex(
                name: "ind_cd_test_fk_f_discipline_id",
                table: "cd_test",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "ind_cd_test_fk_f_student_id",
                table: "cd_test",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_grade");

            migrationBuilder.DropTable(
                name: "cd_test");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
