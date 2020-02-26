using MOD.Entities;
using MOD.TechnologyService.DBContexts;
using System.Collections.Generic;
using System.Linq;

namespace MOD.TechnologyService.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly TechnologyContext _dbContext;
        public SkillRepository(TechnologyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteSkill(int skillId)
        {
            var skill = _dbContext.Skill.Find(skillId);
            _dbContext.Skill.Remove(skill);
            Save();
        }

        public Skill GetSkillById(int skillId)
        {
            return _dbContext.Skill.Find(skillId);
        }

        public IEnumerable<Skill> GetSkills()
        {
            return _dbContext.Skill.ToList();
        }

        public void InsertSkill(Skill skill)
        {
            _dbContext.Add(skill);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            _dbContext.Entry(skill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
