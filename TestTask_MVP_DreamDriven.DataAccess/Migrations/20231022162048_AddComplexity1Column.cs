using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask_MVP_DreamDriven.DataAccess.Migrations
{
    public partial class AddComplexity1Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayCourses",
                table: "Complexity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayCourses",
                table: "Complexity");
        }
    }
}
