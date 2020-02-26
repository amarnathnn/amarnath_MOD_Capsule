using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TechnologyService.Model
{
    public class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Toc { get; set; }
        public string Duration { get; set; }
        public string Prerequisites { get; set; }
        public IList<MentorSkill> MentorSkills { get; set; }
    }
}
