using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamProgramme.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherSurname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    PupilId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Class", "LessonName", "TeacherName", "TeacherSurname" },
                values: new object[,]
                {
                    { 1, 3, "Riyaziyyat", "Gunay", "Ibrahimova" },
                    { 2, 1, "Ana dili", "Aza", "Aliyev" },
                    { 3, 3, "Ingilis dili", "Jale", "Xasiyeva" },
                    { 4, 3, "Informatika", "Ali", "Mamedov" }
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "Class", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 3, "Cavid", "Alagezov" },
                    { 2, 2, "Ali", "Farzaliyev" },
                    { 3, 1, "Vali", "Mamedov" },
                    { 4, 1, "Fidan", "Alagezova" },
                    { 5, 3, "Shefa", "Quliyev" }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "Date", "Grade", "LessonId", "PupilId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1259), 5, 1, 1 },
                    { 2, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1269), 5, 1, 2 },
                    { 3, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1270), 4, 1, 3 },
                    { 4, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1271), 4, 1, 4 },
                    { 5, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1272), 5, 1, 5 },
                    { 6, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1273), 5, 2, 1 },
                    { 7, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1274), 5, 2, 2 },
                    { 8, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1275), 4, 2, 3 },
                    { 9, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1276), 4, 2, 4 },
                    { 10, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1277), 5, 2, 5 },
                    { 11, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1278), 5, 3, 1 },
                    { 12, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1279), 5, 3, 2 },
                    { 13, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1280), 4, 3, 3 },
                    { 14, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1281), 4, 3, 4 },
                    { 15, new DateTime(2023, 6, 2, 1, 0, 46, 457, DateTimeKind.Local).AddTicks(1282), 5, 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonId",
                table: "Exams",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_PupilId",
                table: "Exams",
                column: "PupilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Pupils");
        }
    }
}
