using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.UserService.Migrations
{
    public partial class MentorTableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForceResetPassword",
                table: "Mentors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Mentors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ForceResetPassword",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Mentors");
        }
    }
}
