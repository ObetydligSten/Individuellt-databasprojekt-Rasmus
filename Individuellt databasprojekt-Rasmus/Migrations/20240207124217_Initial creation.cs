using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Individuellt_databasprojekt_Rasmus.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurss",
                columns: table => new
                {
                    KursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurss", x => x.KursId);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Befattning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YearsService = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.PersonalId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonNr = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Betygs",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    GradeSet = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betygs", x => new { x.StudentId, x.PersonalId, x.KursId });
                    table.ForeignKey(
                        name: "FK_Betygs_Kurss_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurss",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Betygs_Personals_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personals",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Betygs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kurss",
                columns: new[] { "KursId", "Active", "KursName" },
                values: new object[,]
                {
                    { 1, false, "Svenska" },
                    { 2, false, "Engelska" },
                    { 3, true, "Matematik" },
                    { 4, false, "Programmering" }
                });

            migrationBuilder.InsertData(
                table: "Personals",
                columns: new[] { "PersonalId", "Befattning", "FirstName", "LastName", "Salary", "YearsService" },
                values: new object[,]
                {
                    { 1, "Admin", "Chris", "Jakobsson", 30000, 6 },
                    { 2, "Lärare", "Eva", "Andersson", 35000, 8 },
                    { 3, "Vaktmästare", "David", "Pettersson", 28000, 4 },
                    { 4, "Lärare", "Sofia", "Lindgren", 32000, 3 },
                    { 5, "IT-tekniker", "Lars", "Gustavsson", 38000, 5 },
                    { 6, "Lärare", "Emma", "Andersson", 26000, 2 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Class", "FirstName", "LastName", "PersonNr" },
                values: new object[,]
                {
                    { 1, "A1", "Lasse", "Persson", "19850312-1234" },
                    { 2, "B2", "Anna", "Andersson", "19901005-5678" },
                    { 3, "A1", "Erik", "Ekström", "19930420-9012" },
                    { 4, "B2", "Maria", "Månsson", "19970215-3456" },
                    { 5, "C3", "Karl", "Karlsson", "19981230-7890" },
                    { 6, "B2", "Sara", "Svensson", "20010325-2345" },
                    { 7, "A1", "Johan", "Johansson", "19940810-6789" },
                    { 8, "A1", "Emma", "Engström", "19871203-0123" },
                    { 9, "C3", "Peter", "Petersson", "20000218-4567" },
                    { 10, "B2", "Lisa", "Lindström", "19921205-8901" },
                    { 11, "A1", "Anders", "Andersson", "20000120-2345" }
                });

            migrationBuilder.InsertData(
                table: "Betygs",
                columns: new[] { "KursId", "PersonalId", "StudentId", "Grade", "GradeSet" },
                values: new object[,]
                {
                    { 1, 2, 1, 3, new DateOnly(2023, 11, 1) },
                    { 4, 2, 1, 5, new DateOnly(2024, 1, 28) },
                    { 1, 4, 2, 3, new DateOnly(2024, 2, 5) },
                    { 2, 4, 2, 4, new DateOnly(2023, 10, 15) },
                    { 2, 6, 3, 4, new DateOnly(2023, 10, 25) },
                    { 3, 6, 3, 5, new DateOnly(2023, 12, 5) },
                    { 3, 2, 4, 1, new DateOnly(2023, 12, 10) },
                    { 4, 2, 4, 3, new DateOnly(2023, 11, 20) },
                    { 1, 4, 5, 4, new DateOnly(2023, 12, 10) },
                    { 4, 4, 5, 3, new DateOnly(2024, 1, 20) },
                    { 1, 2, 6, 2, new DateOnly(2023, 12, 15) },
                    { 2, 2, 6, 5, new DateOnly(2023, 10, 30) },
                    { 2, 6, 7, 5, new DateOnly(2023, 10, 30) },
                    { 3, 6, 7, 3, new DateOnly(2023, 12, 25) },
                    { 3, 4, 8, 3, new DateOnly(2023, 12, 10) },
                    { 4, 4, 8, 4, new DateOnly(2023, 11, 12) },
                    { 1, 2, 9, 5, new DateOnly(2023, 12, 1) },
                    { 4, 2, 9, 2, new DateOnly(2023, 11, 25) },
                    { 1, 4, 10, 1, new DateOnly(2023, 12, 5) },
                    { 2, 4, 10, 3, new DateOnly(2023, 10, 20) },
                    { 3, 6, 11, 4, new DateOnly(2023, 12, 15) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Betygs_KursId",
                table: "Betygs",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Betygs_PersonalId",
                table: "Betygs",
                column: "PersonalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Betygs");

            migrationBuilder.DropTable(
                name: "Kurss");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
