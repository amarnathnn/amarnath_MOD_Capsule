using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.UserService.Migrations
{
    public partial class UpdateMentorEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Mentors",
                newName: "EmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "Mentors",
                newName: "Email");
        }
    }
}
