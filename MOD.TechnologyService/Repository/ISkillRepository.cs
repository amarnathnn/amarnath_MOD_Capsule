using MOD.Entities;
using System.Collections.Generic;

namespace MOD.TechnologyService.Repository
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetSkills();
        Skill GetSkillById(int skillId);
        void InsertSkill(Skill skill);
        void DeleteSkill(int skillId);
        void UpdateSkill(Skill skill);
        void Save();

    }
}
