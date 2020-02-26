using Microsoft.EntityFrameworkCore;
using MOD.Entities;

namespace MOD.UserService
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorCalendar> MentorCalendars { get; set; }
        public DbSet<MentorSkill> MentorSkills { get; set; }
       
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorSkill>().HasKey(ms => new { ms.MentorId, ms.SkillId });
        }
    }
}
