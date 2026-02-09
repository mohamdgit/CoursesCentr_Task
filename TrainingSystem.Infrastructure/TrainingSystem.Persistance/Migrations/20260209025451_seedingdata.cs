using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "hours" },
                values: new object[,]
                {
                    { -3, "EF Core Advanced", 19 },
                    { -2, "C# Basics", 15 },
                    { -1, "ASP.NET Core", 15 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { -3, "sara@example.com", "Sara", "0123456787" },
                    { -2, "ahmed@example.com", "Ahmed", "0123456788" },
                    { -1, "mohamed@example.com", "Mohamed", "0123456789" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CourseId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { -2, -2, "Mona@example.com", "Mrs. Mona", "0123456789" },
                    { -1, -1, "ali@example.com", "Mr. Ali", "0123456789" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { -1, -3 },
                    { -2, -2 },
                    { -1, -1 }
                });

            migrationBuilder.InsertData(
                table: "InstructorStudents",
                columns: new[] { "InstructorId", "StudentId" },
                values: new object[,]
                {
                    { -1, -3 },
                    { -2, -2 },
                    { -1, -1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "InstructorStudents",
                keyColumns: new[] { "InstructorId", "StudentId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "InstructorStudents",
                keyColumns: new[] { "InstructorId", "StudentId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "InstructorStudents",
                keyColumns: new[] { "InstructorId", "StudentId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
