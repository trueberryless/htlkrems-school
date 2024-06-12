using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("CREATURE_HAS_SKILLS_JT")]
public class SkillItem {

    public Creature Creature { get; set; }

    [Column("CREATURE_ID")]
    public int CreatureId { get; set; }

    public Skill Skill { get; set; }

    [Column("SKILL_ID")]
    public int SkillId { get; set; }

}