using Microsoft.EntityFrameworkCore;
using MOD.Entities;

namespace MOD.SearchService
{
    public class SearchContext : DbContext
    {
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorSkill> MentorSkills { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<MentorCalendar> MentorCalendars { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public SearchContext(DbContextOptions<SearchContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorSkill>().HasKey(ms => new { ms.MentorId, ms.SkillId });
            modelBuilder.Entity<MentorSkill>().HasOne(ms => ms.Mentor)
                                               .WithMany(m => m.MentorSkills)
                                               .HasForeignKey(ms => ms.MentorId);
            modelBuilder.Entity<MentorSkill>().HasOne(ms => ms.Skill)
                                              .WithMany(s => s.MentorSkills)
                                              .HasForeignKey(ms => ms.SkillId);
        }
    }
}
