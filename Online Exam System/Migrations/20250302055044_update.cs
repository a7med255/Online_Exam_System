using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Exam_System.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbUserAnswers_TbQuestions_QuestionId",
                table: "TbUserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserExams_AspNetUsers_UserId",
                table: "TbUserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserExams_TbExams_ExamId",
                table: "TbUserExams");

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserAnswers_TbQuestions_QuestionId",
                table: "TbUserAnswers",
                column: "QuestionId",
                principalTable: "TbQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserExams_AspNetUsers_UserId",
                table: "TbUserExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserExams_TbExams_ExamId",
                table: "TbUserExams",
                column: "ExamId",
                principalTable: "TbExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbUserAnswers_TbQuestions_QuestionId",
                table: "TbUserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserExams_AspNetUsers_UserId",
                table: "TbUserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserExams_TbExams_ExamId",
                table: "TbUserExams");

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserAnswers_TbQuestions_QuestionId",
                table: "TbUserAnswers",
                column: "QuestionId",
                principalTable: "TbQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserExams_AspNetUsers_UserId",
                table: "TbUserExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserExams_TbExams_ExamId",
                table: "TbUserExams",
                column: "ExamId",
                principalTable: "TbExams",
                principalColumn: "Id");
        }
    }
}
