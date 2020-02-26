namespace MOD.Entities
{
    public class MentorSkill
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
