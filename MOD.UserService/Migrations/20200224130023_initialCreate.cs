using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.UserService.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MentorName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    LinkedInUrl = table.Column<string>(nullable: true),
                    RegistrationDateTime = table.Column<DateTime>(nullable: false),
                    RegCode = table.Column<string>(nullable: true),
                    YearsOfExperience = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.MentorId);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Toc = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Prerequisites = table.Column<string>(nullable: true),
                    Fees = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Userid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    RegCode = table.Column<string>(nullable: true),
                    ForceResetPassword = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    EmailId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Userid);
                });

            migrationBuilder.CreateTable(
                name: "MentorCalendars",
                columns: table => new
                {
                    MentorCalendarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MentorId = table.Column<int>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Timing = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorCalendars", x => x.MentorCalendarId);
                    table.ForeignKey(
                        name: "FK_MentorCalendars_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorSkills",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorSkills", x => new { x.MentorId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_MentorSkills_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorSkills_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    MentorId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Progress = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Timing = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_Trainings_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MentorId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false),
                    TransactionType = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_Payment_Trainings_TrainingId",
                    //    column: x => x.TrainingId,
                    //    principalTable: "Trainings",
                    //    principalColumn: "TrainingId",
                    //    onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorCalendars_MentorId",
                table: "MentorCalendars",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorSkills_SkillId",
                table: "MentorSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_MentorId",
                table: "Payment",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TrainingId",
                table: "Payment",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserId",
                table: "Payment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_MentorId",
                table: "Trainings",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_SkillId",
                table: "Trainings",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_UserId",
                table: "Trainings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorCalendars");

            migrationBuilder.DropTable(
                name: "MentorSkills");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
