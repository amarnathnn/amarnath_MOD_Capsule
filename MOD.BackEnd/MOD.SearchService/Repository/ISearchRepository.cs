using MOD.Entities;
using System.Collections.Generic;

namespace MOD.SearchService.Repository
{
    public interface ISearchRepository
    {
        IEnumerable<Mentor> GetMentors();
        List<Mentor> GetMentorbySkillId(int skillId);
        void Save();

        //void InsertSkill(Skill skill);
        //void DeleteSkill(int skillId);
        //void UpdateSkill(Skill skill);

    }
}
