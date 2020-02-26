using MOD.SearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TechnologyService.Model
{
    public class MentorSkill
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
