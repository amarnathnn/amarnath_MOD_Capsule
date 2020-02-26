using Microsoft.EntityFrameworkCore;
using MOD.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MOD.SearchService.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly SearchContext _dbContext;
        public SearchRepository(SearchContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Mentor> GetMentorbySkillId(int skillId)
        {
            /*var lstMentors = _dbContext.Mentors.Include(m => m.MentorCalendars).Include(m=>m.MentorSkills).ThenInclude(ms=>ms.Skill)
                .Where(m => m.MentorSkills.Any(s => s.SkillId == skillId)).ToList();*/
            var lstMentors = _dbContext.Mentors.Include(m => m.MentorCalendars).Include(mentor => mentor.MentorTrainings)
                .Include(m => m.MentorSkills).ThenInclude(ms => ms.Skill)
                .Where(m => m.MentorSkills.Any(s => s.SkillId == skillId)).ToList();
            return lstMentors;
        }

        public IEnumerable<Mentor> GetMentors()
        {
            return _dbContext.Mentors.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region Commented
        /*

        public void UpdateSkill(Skill skill)
        {
            _dbContext.Entry(skill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        public void DeleteSkill(int skillId)
        {
            var skill = _dbContext.Skills.Find(skillId);
            _dbContext.Skills.Remove(skill);
            Save();
        }

        public void InsertSkill(Skill skill)
        {
            _dbContext.Add(skill);
            Save();
        }*/

        #endregion
    }
}
