using Microsoft.EntityFrameworkCore;
using MOD.Entities;

namespace MOD.PaymentService
{
    public class PaymentContext : DbContext
    {
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skill { get; set; }
       
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorSkill>().HasKey(ms => new { ms.MentorId, ms.SkillId });
        }
    }
}
