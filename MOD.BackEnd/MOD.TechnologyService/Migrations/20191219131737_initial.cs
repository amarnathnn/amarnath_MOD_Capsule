using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.TechnologyService.Migrations
{
    public partial class initial : Migration
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
                name: "Skills",
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
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
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
                    Active = table.Column<bool>(nullable: false)
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
                    EndDate = table.Column<DateTime>(nullable: true)
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
                        name: "FK_MentorSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
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
                        name: "FK_Trainings_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
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
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MentorId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false),
                    TransactionType = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mentors",
                columns: new[] { "MentorId", "Email", "LinkedInUrl", "MentorName", "Password", "RegCode", "RegistrationDateTime", "YearsOfExperience", "active" },
                values: new object[,]
                {
                    { 1, "mentor1@abc.com", "www.mentor1.com", "Mentor 1", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false },
                    { 2, "mentor2@abc.com", "www.mentor2.com", "Mentor 2", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, false },
                    { 3, "mentor3@abc.com", "www.mentor3.com", "Mentor 3", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, false },
                    { 4, "mentor4@abc.com", "www.mentor4.com", "Mentor 4", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Duration", "Fees", "Name", "Prerequisites", "Toc" },
                values: new object[,]
                {
                    { 1, "2 weeks", 500m, "WebApiCore", ".Net", "sample table of contents for webapi" },
                    { 2, "2 weeks", 1000m, "Angular", "Javascript", "sample table of contents for angular" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Userid", "Active", "ContactNumber", "FirstName", "ForceResetPassword", "LastName", "Password", "RegCode", "RegistrationDate", "UserName" },
                values: new object[,]
                {
                    { 1, true, "1234567890", "User1", false, "User1", "password", null, new DateTime(2019, 12, 19, 18, 47, 36, 740, DateTimeKind.Local), "UserName1" },
                    { 2, true, "1234567890", "User2", false, "User2", "password", null, new DateTime(2019, 12, 19, 18, 47, 36, 740, DateTimeKind.Local), "UserName2" },
                    { 3, true, "1234567890", "User3", false, "User3", "password", null, new DateTime(2019, 12, 19, 18, 47, 36, 740, DateTimeKind.Local), "UserName3" }
                });

            migrationBuilder.InsertData(
                table: "MentorCalendars",
                columns: new[] { "MentorCalendarId", "EndDate", "EndTime", "MentorId", "StartDate", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), "11AM", 1, new DateTime(2019, 12, 19, 18, 47, 36, 737, DateTimeKind.Local), "9AM" },
                    { 2, new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), "4PM", 1, new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), "2PM" },
                    { 3, new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), "4PM", 2, new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), "2PM" },
                    { 4, new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), "4PM", 3, new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), "2PM" },
                    { 5, new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), "4PM", 4, new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), "2PM" }
                });

            migrationBuilder.InsertData(
                table: "MentorSkills",
                columns: new[] { "MentorId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "TrainingId", "EndDate", "MentorId", "Progress", "Rating", "SkillId", "StartDate", "Status", "Timing", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 18, 18, 47, 36, 739, DateTimeKind.Local), 1, "10%", 1, 1, new DateTime(2019, 12, 19, 18, 47, 36, 739, DateTimeKind.Local), "in progress", "2pm-4pm", 1 },
                    { 2, new DateTime(2020, 1, 18, 18, 47, 36, 739, DateTimeKind.Local), 2, "10%", 1, 2, new DateTime(2019, 12, 19, 18, 47, 36, 739, DateTimeKind.Local), "in progress", "9am-11am", 2 },
                    { 3, new DateTime(2020, 1, 18, 18, 47, 36, 739, DateTimeKind.Local), 3, "10%", 1, 1, new DateTime(2019, 12, 19, 18, 47, 36, 739, DateTimeKind.Local), "in progress", "9am-11am", 3 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "MentorId", "PaymentDate", "Remarks", "TrainingId", "TransactionType", "UserId" },
                values: new object[] { 1, 100m, 1, new DateTime(2019, 12, 19, 18, 47, 36, 741, DateTimeKind.Local), "test payment", 1, "debit card", 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "MentorId", "PaymentDate", "Remarks", "TrainingId", "TransactionType", "UserId" },
                values: new object[] { 2, 150m, 2, new DateTime(2019, 12, 19, 18, 47, 36, 742, DateTimeKind.Local), "test payment", 2, "cash", 2 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "MentorId", "PaymentDate", "Remarks", "TrainingId", "TransactionType", "UserId" },
                values: new object[] { 3, 200m, 3, new DateTime(2019, 12, 19, 18, 47, 36, 742, DateTimeKind.Local), "test payment", 3, "online payment", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MentorCalendars_MentorId",
                table: "MentorCalendars",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorSkills_SkillId",
                table: "MentorSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MentorId",
                table: "Payments",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TrainingId",
                table: "Payments",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
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
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
