﻿// <auto-generated />
using System;
using MOD.TechnologyService.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MOD.TechnologyService.Migrations
{
    [DbContext(typeof(TechnologyContext))]
    partial class TechnologyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MOD.Entities.Mentor", b =>
                {
                    b.Property<int>("MentorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("LinkedInUrl");

                    b.Property<string>("MentorName");

                    b.Property<string>("Password");

                    b.Property<string>("RegCode");

                    b.Property<DateTime>("RegistrationDateTime");

                    b.Property<int>("YearsOfExperience");

                    b.Property<bool?>("active");

                    b.HasKey("MentorId");

                    b.ToTable("Mentors");

                    b.HasData(
                        new { MentorId = 1, Email = "mentor1@abc.com", LinkedInUrl = "www.mentor1.com", MentorName = "Mentor 1", RegistrationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), YearsOfExperience = 5, active = false },
                        new { MentorId = 2, Email = "mentor2@abc.com", LinkedInUrl = "www.mentor2.com", MentorName = "Mentor 2", RegistrationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), YearsOfExperience = 7, active = false },
                        new { MentorId = 3, Email = "mentor3@abc.com", LinkedInUrl = "www.mentor3.com", MentorName = "Mentor 3", RegistrationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), YearsOfExperience = 9, active = false },
                        new { MentorId = 4, Email = "mentor4@abc.com", LinkedInUrl = "www.mentor4.com", MentorName = "Mentor 4", RegistrationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), YearsOfExperience = 10, active = false }
                    );
                });

            modelBuilder.Entity("MOD.Entities.MentorCalendar", b =>
                {
                    b.Property<int>("MentorCalendarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("EndTime");

                    b.Property<int>("MentorId");

                    b.Property<DateTime?>("StartDate");

                    b.Property<string>("StartTime");

                    b.HasKey("MentorCalendarId");

                    b.HasIndex("MentorId");

                    b.ToTable("MentorCalendars");

                    b.HasData(
                        new { MentorCalendarId = 1, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), EndTime = "11AM", MentorId = 1, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 737, DateTimeKind.Local), StartTime = "9AM" },
                        new { MentorCalendarId = 2, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), EndTime = "4PM", MentorId = 1, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), StartTime = "2PM" },
                        new { MentorCalendarId = 3, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), EndTime = "4PM", MentorId = 2, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), StartTime = "2PM" },
                        new { MentorCalendarId = 4, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), EndTime = "4PM", MentorId = 3, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), StartTime = "2PM" },
                        new { MentorCalendarId = 5, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 738, DateTimeKind.Local), EndTime = "4PM", MentorId = 4, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 738, DateTimeKind.Local), StartTime = "2PM" }
                    );
                });

            modelBuilder.Entity("MOD.Entities.MentorSkill", b =>
                {
                    b.Property<int>("MentorId");

                    b.Property<int>("SkillId");

                    b.HasKey("MentorId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("MentorSkills");

                    b.HasData(
                        new { MentorId = 1, SkillId = 1 },
                        new { MentorId = 1, SkillId = 2 },
                        new { MentorId = 2, SkillId = 2 },
                        new { MentorId = 3, SkillId = 1 },
                        new { MentorId = 4, SkillId = 2 }
                    );
                });

            modelBuilder.Entity("MOD.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("MentorId");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("Remarks");

                    b.Property<int>("TrainingId");

                    b.Property<string>("TransactionType");

                    b.Property<int>("UserId");

                    b.HasKey("PaymentId");

                    b.HasIndex("MentorId");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");

                    b.HasData(
                        new { PaymentId = 1, Amount = 100m, MentorId = 1, PaymentDate = new DateTime(2019, 12, 19, 18, 47, 36, 741, DateTimeKind.Local), Remarks = "test payment", TrainingId = 1, TransactionType = "debit card", UserId = 1 },
                        new { PaymentId = 2, Amount = 150m, MentorId = 2, PaymentDate = new DateTime(2019, 12, 19, 18, 47, 36, 742, DateTimeKind.Local), Remarks = "test payment", TrainingId = 2, TransactionType = "cash", UserId = 2 },
                        new { PaymentId = 3, Amount = 200m, MentorId = 3, PaymentDate = new DateTime(2019, 12, 19, 18, 47, 36, 742, DateTimeKind.Local), Remarks = "test payment", TrainingId = 3, TransactionType = "online payment", UserId = 2 }
                    );
                });

            modelBuilder.Entity("MOD.Entities.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Duration");

                    b.Property<decimal>("Fees");

                    b.Property<string>("Name");

                    b.Property<string>("Prerequisites");

                    b.Property<string>("Toc");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");

                    b.HasData(
                        new { SkillId = 1, Duration = "2 weeks", Fees = 500m, Name = "WebApiCore", Prerequisites = ".Net", Toc = "sample table of contents for webapi" },
                        new { SkillId = 2, Duration = "2 weeks", Fees = 1000m, Name = "Angular", Prerequisites = "Javascript", Toc = "sample table of contents for angular" }
                    );
                });

            modelBuilder.Entity("MOD.Entities.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MentorId");

                    b.Property<string>("Progress");

                    b.Property<int>("Rating");

                    b.Property<int>("SkillId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.Property<string>("Timing");

                    b.Property<int>("UserId");

                    b.HasKey("TrainingId");

                    b.HasIndex("MentorId");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("Trainings");

                    b.HasData(
                        new { TrainingId = 1, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 739, DateTimeKind.Local), MentorId = 1, Progress = "10%", Rating = 1, SkillId = 1, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 739, DateTimeKind.Local), Status = "in progress", Timing = "2pm-4pm", UserId = 1 },
                        new { TrainingId = 2, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 739, DateTimeKind.Local), MentorId = 2, Progress = "10%", Rating = 1, SkillId = 2, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 739, DateTimeKind.Local), Status = "in progress", Timing = "9am-11am", UserId = 2 },
                        new { TrainingId = 3, EndDate = new DateTime(2020, 1, 18, 18, 47, 36, 739, DateTimeKind.Local), MentorId = 3, Progress = "10%", Rating = 1, SkillId = 1, StartDate = new DateTime(2019, 12, 19, 18, 47, 36, 739, DateTimeKind.Local), Status = "in progress", Timing = "9am-11am", UserId = 3 }
                    );
                });

            modelBuilder.Entity("MOD.Entities.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("FirstName");

                    b.Property<bool>("ForceResetPassword");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("RegCode");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("UserName");

                    b.HasKey("Userid");

                    b.ToTable("Users");

                    b.HasData(
                        new { Userid = 1, Active = true, ContactNumber = "1234567890", FirstName = "User1", ForceResetPassword = false, LastName = "User1", Password = "password", RegistrationDate = new DateTime(2019, 12, 19, 18, 47, 36, 740, DateTimeKind.Local), UserName = "UserName1" },
                        new { Userid = 2, Active = true, ContactNumber = "1234567890", FirstName = "User2", ForceResetPassword = false, LastName = "User2", Password = "password", RegistrationDate = new DateTime(2019, 12, 19, 18, 47, 36, 740, DateTimeKind.Local), UserName = "UserName2" },
                        new { Userid = 3, Active = true, ContactNumber = "1234567890", FirstName = "User3", ForceResetPassword = false, LastName = "User3", Password = "password", RegistrationDate = new DateTime(2019, 12, 19, 18, 47, 36, 740, DateTimeKind.Local), UserName = "UserName3" }
                    );
                });

            modelBuilder.Entity("MOD.Entities.MentorCalendar", b =>
                {
                    b.HasOne("MOD.Entities.Mentor", "Mentor")
                        .WithMany("MentorCalendars")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MOD.Entities.MentorSkill", b =>
                {
                    b.HasOne("MOD.Entities.Mentor", "Mentor")
                        .WithMany("MentorSkills")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MOD.Entities.Skill", "Skill")
                        .WithMany("MentorSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MOD.Entities.Payment", b =>
                {
                    b.HasOne("MOD.Entities.Mentor", "Mentor")
                        .WithMany("MentorPayments")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MOD.Entities.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MOD.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MOD.Entities.Training", b =>
                {
                    b.HasOne("MOD.Entities.Mentor", "Mentor")
                        .WithMany("MentorTrainings")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MOD.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MOD.Entities.User", "User")
                        .WithMany("UserTrainings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}