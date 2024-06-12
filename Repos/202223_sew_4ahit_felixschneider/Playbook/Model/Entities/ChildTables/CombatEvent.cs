using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("COMBAT_EVENTS")]
public class CombatEvent : AEvent
{
    [Required]
    [Column("CREATURE_ID")]
    public int CreatureId { get; set; }
    
    public Creature Creature { get; set; }
}