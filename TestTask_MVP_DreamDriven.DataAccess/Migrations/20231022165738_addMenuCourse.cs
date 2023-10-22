using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask_MVP_DreamDriven.DataAccess.Migrations
{
    public partial class addMenuCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfLessons = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ComplexityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuCourse_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuCourse_Complexity_ComplexityId",
                        column: x => x.ComplexityId,
                        principalTable: "Complexity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCourse_CategoryId",
                table: "MenuCourse",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCourse_ComplexityId",
                table: "MenuCourse",
                column: "ComplexityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuCourse");
        }
    }
}
