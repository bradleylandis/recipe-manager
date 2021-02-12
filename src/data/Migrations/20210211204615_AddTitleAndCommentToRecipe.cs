using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class AddTitleAndCommentToRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Recipes");
        }
    }
}
