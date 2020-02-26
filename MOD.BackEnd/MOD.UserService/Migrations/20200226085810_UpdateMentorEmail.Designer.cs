﻿// <auto-generated />
using System;
using MOD.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MOD.UserService.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20200226085810_UpdateMentorEmail")]
    partial class UpdateMentorEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ContactNumber");

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("ForceResetPassword");

                    b.Property<string>("LastName");

                    b.Property<string>("LinkedInUrl");

                    b.Property<string>("MentorName");

                    b.Property<string>("Password");

                    b.Property<string>("RegCode");

                    b.Property<DateTime>("RegistrationDateTime");

                    b.Property<int>("YearsOfExperience");

                    b.Property<bool?>("active");

                    b.HasKey("MentorId");

                    b.ToTable("Mentors");
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

                    b.Property<string>("Timing");

                    b.HasKey("MentorCalendarId");

                    b.HasIndex("MentorId");

                    b.ToTable("MentorCalendars");
                });

            modelBuilder.Entity("MOD.Entities.MentorSkill", b =>
                {
                    b.Property<int>("MentorId");

                    b.Property<int>("SkillId");

                    b.HasKey("MentorId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("MentorSkills");
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

                    b.Property<decimal>("Tax");

                    b.Property<int>("TrainingId");

                    b.Property<string>("TransactionType");

                    b.Property<int>("UserId");

                    b.HasKey("PaymentId");

                    b.HasIndex("MentorId");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("Payment");
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

                    b.ToTable("Skill");
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
                });

            modelBuilder.Entity("MOD.Entities.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("ForceResetPassword");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("RegCode");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("UserName");

                    b.HasKey("Userid");

                    b.ToTable("Users");
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
