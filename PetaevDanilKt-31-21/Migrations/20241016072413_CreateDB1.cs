using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetaevDanilKt_31_21.Migrations
{
    public partial class CreateDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Disciplines_disciplineId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Student_studentId",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "ind_Grade_fk_student_id",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Grade");

            migrationBuilder.RenameColumn(
                name: "disciplineId",
                table: "Grade",
                newName: "DisciplineId");

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "Grade",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Идентификатор предмета");

            migrationBuilder.CreateTable(
                name: "GradeStudent",
                columns: table => new
                {
                    GradesId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeStudent", x => new { x.GradesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GradeStudent_Grade_GradesId",
                        column: x => x.GradesId,
                        principalTable: "Grade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeStudent_StudentsId",
                table: "GradeStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Disciplines_DisciplineId",
                table: "Grade",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Disciplines_DisciplineId",
                table: "Grade");

            migrationBuilder.DropTable(
                name: "GradeStudent");

            migrationBuilder.RenameColumn(
                name: "DisciplineId",
                table: "Grade",
                newName: "disciplineId");

            migrationBuilder.AlterColumn<int>(
                name: "disciplineId",
                table: "Grade",
                type: "int4",
                nullable: false,
                comment: "Идентификатор предмета",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Grade",
                type: "int4",
                nullable: false,
                defaultValue: 0,
                comment: "Идентификатор студента");

            migrationBuilder.CreateIndex(
                name: "ind_Grade_fk_student_id",
                table: "Grade",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Disciplines_disciplineId",
                table: "Grade",
                column: "disciplineId",
                principalTable: "Disciplines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Student_studentId",
                table: "Grade",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
