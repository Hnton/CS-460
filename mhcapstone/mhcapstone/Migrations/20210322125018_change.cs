using Microsoft.EntityFrameworkCore.Migrations;

namespace mhcapstone.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionsType",
                schema: "User",
                table: "SurveyInfo");

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                schema: "User",
                table: "SurveyInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answers",
                schema: "User",
                table: "SurveyInfo");

            migrationBuilder.AddColumn<bool>(
                name: "QuestionsType",
                schema: "User",
                table: "SurveyInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
