using Microsoft.EntityFrameworkCore;
using MOD.Entities;
using System;

namespace MOD.TechnologyService.DBContexts
{
    public class TechnologyContext : DbContext
    {
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorCalendar> MentorCalendars { get; set; }
        public DbSet<MentorSkill> MentorSkills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public TechnologyContext(DbContextOptions<TechnologyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorSkill>().HasKey(ms => new { ms.MentorId, ms.SkillId });
            //  modelBuilder.Entity<Mentor>
            var skills = new[]
            {
                     new Skill()
                {
                    SkillId = 1,
                    Name = "WebApiCore",
                    Duration = "2 weeks",
                    Prerequisites = ".Net",
                    Toc = "sample table of contents for webapi",
                     Fees=500
                },
                 new Skill()
                 {
                     SkillId = 2,
                     Name = "Angular",
                     Duration = "2 weeks",
                     Prerequisites = "Javascript",
                     Toc = "sample table of contents for angular",
                     Fees=1000
                 }
             };
            var mentors = new[]
            {
                new Mentor()
                {
                     MentorId=1,
                      MentorName="Mentor 1",
                      LinkedInUrl="www.mentor1.com",
                      active=false,
                      YearsOfExperience=5,
                       EmailId="mentor1@abc.com"
                },
                new Mentor()
                {
                     MentorId=2,
                      MentorName="Mentor 2",
                      LinkedInUrl="www.mentor2.com",
                      active=false,
                      YearsOfExperience=7,
                       EmailId="mentor2@abc.com"
                },
                new Mentor()
                {
                     MentorId=3,
                      MentorName="Mentor 3",
                      LinkedInUrl="www.mentor3.com",
                      active=false,
                      YearsOfExperience=9,
                       EmailId="mentor3@abc.com"
                },
                new Mentor()
                {
                     MentorId=4,
                      MentorName="Mentor 4",
                      LinkedInUrl="www.mentor4.com",
                      active=false,
                      YearsOfExperience=10,
                       EmailId="mentor4@abc.com"
                },
            };
            var mentorCalendars = new[]
            {
                new MentorCalendar()
                {
                    MentorCalendarId=1,
                    MentorId=1,
                    StartTime="9AM",
                    EndTime="11AM",
                    StartDate=DateTime.Now,
                    EndDate =DateTime.Now.AddDays(30),
                    Timing="9am-11am"
                },
                new MentorCalendar()
                {
                      MentorCalendarId=2,
                    MentorId=1,
                    StartTime="2PM",
                    EndTime="4PM",
                    StartDate=DateTime.Now,
                    EndDate =DateTime.Now.AddDays(30),
                    Timing="9am-11am"

                },
                 new MentorCalendar()
                {
                       MentorCalendarId=3,
                    MentorId=2,
                    StartTime="2PM",
                    EndTime="4PM",
                    StartDate=DateTime.Now,
                    EndDate =DateTime.Now.AddDays(30),
                    Timing="9am-11am"

                },
                  new MentorCalendar()
                {
                        MentorCalendarId=4,
                    MentorId=3,
                    StartTime="2PM",
                    EndTime="4PM",
                    StartDate=DateTime.Now,
                    EndDate =DateTime.Now.AddDays(30),
                    Timing="9am-11am"

                },
                   new MentorCalendar()
                {
                       MentorCalendarId=5,
                    MentorId=4,
                    StartTime="2PM",
                    EndTime="4PM",
                    StartDate=DateTime.Now,
                    EndDate =DateTime.Now.AddDays(30),
                    Timing="9am-11am"

                },
            };
            var mentorSkills = new[]
            {
                new MentorSkill()
                {
                     MentorId=1,
                     SkillId=1
                },
                  new MentorSkill()
                {
                     MentorId=1,
                     SkillId=2
                },
                    new MentorSkill()
                {
                     MentorId=2,
                     SkillId=2
                },
                      new MentorSkill()
                {
                     MentorId=3,
                     SkillId=1
                },
                        new MentorSkill()
                {
                     MentorId=4,
                     SkillId=2
                }
            };
            var mentorTrainings = new[]
            {
                new Training()
                {
                     MentorId=1,
                      Progress="10%",
                       Rating=1,
                        Status="in progress",
                         UserId=1,
                          SkillId=1,
                           StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(30),
                             TrainingId=1,
                              Timing="2pm-4pm",


                },
                  new Training()
                {
                     MentorId=2,
                      Progress="10%",
                       Rating=1,
                        Status="in progress",
                         UserId=2,
                          SkillId=2,
                           StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(30),
                             TrainingId=2,
                              Timing="9am-11am"


                },
                    new Training()
                {
                     MentorId=3,
                      Progress="10%",
                       Rating=1,
                        Status="in progress",
                         UserId=3,
                          SkillId=1,
                           StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(30),
                             TrainingId=3,
                              Timing="9am-11am"


                }
            };
            var users = new[]
            {
                new User()
                {
                     Userid=1,
                      Active=true,
                       ContactNumber="1234567890",
                        FirstName="User1",
                         LastName="User1",
                          ForceResetPassword=false,
                           Password="password",
                            RegistrationDate=DateTime.Now,
                             UserName="UserName1"
                },
                new User()
                {
                     Userid=2,
                      Active=true,
                       ContactNumber="1234567890",
                        FirstName="User2",
                         LastName="User2",
                          ForceResetPassword=false,
                           Password="password",
                            RegistrationDate=DateTime.Now,
                             UserName="UserName2"
                },
                new User()
                {
                     Userid=3,
                      Active=true,
                       ContactNumber="1234567890",
                        FirstName="User3",
                         LastName="User3",
                          ForceResetPassword=false,
                           Password="password",
                            RegistrationDate=DateTime.Now,
                             UserName="UserName3"
                }
            };
            var payments = new[]
            {
                new Payment()
                {
                     PaymentDate=DateTime.Now,
                     PaymentId=1,
                      Amount=100,
                       MentorId=1,
                        Remarks="test payment",
                         TrainingId=1,
                          TransactionType="debit card",
                           UserId=1,
                            Tax=5


                },
                new Payment()
                {
                     PaymentDate=DateTime.Now,
                     PaymentId=2,
                      Amount=150,
                       MentorId=2,
                        Remarks="test payment",
                         TrainingId=2,
                          TransactionType="cash",
                          UserId=2,
                            Tax=5

                },
                new Payment()
                {
                     PaymentDate=DateTime.Now,
                     PaymentId=3,
                      Amount=200,
                       MentorId=3,
                        Remarks="test payment",
                         TrainingId=3,
                          TransactionType="online payment",
                          UserId=2,
                            Tax=5

                },
            };
            modelBuilder.Entity<Skill>().HasData(skills[0], skills[1]);
            modelBuilder.Entity<Mentor>().HasData(mentors[0], mentors[1], mentors[2], mentors[3]);
            modelBuilder.Entity<MentorSkill>().HasData(mentorSkills[0], mentorSkills[1], mentorSkills[2], mentorSkills[3], mentorSkills[4]);
            modelBuilder.Entity<MentorCalendar>().HasData(mentorCalendars[0], mentorCalendars[1], mentorCalendars[2], mentorCalendars[3], mentorCalendars[4]);
            modelBuilder.Entity<User>().HasData(users[0], users[1], users[2]);
            modelBuilder.Entity<Training>().HasData(mentorTrainings[0], mentorTrainings[1], mentorTrainings[2]);
            modelBuilder.Entity<Payment>().HasData(payments[0], payments[1], payments[2]);
            base.OnModelCreating(modelBuilder);
        }
    }
}
