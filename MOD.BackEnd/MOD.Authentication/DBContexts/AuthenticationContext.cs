using Microsoft.EntityFrameworkCore;
using MOD.Entities;

namespace MOD.AuthenticationService
{
    public class AuthenticationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
       
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorSkill>().HasKey(ms => new { ms.MentorId, ms.SkillId });
        }
    }
}
