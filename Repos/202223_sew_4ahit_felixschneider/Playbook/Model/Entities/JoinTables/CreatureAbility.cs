using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("CREATURE_HAS_ABILITIES_JT")]
public class CreatureAbility
{
    [Required]
    [Column("CREATURE_ID")]
    public int CreatureId { get; set; }
    
    [NotMapped]
    public Creature Creature { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column("ABILITY_TYPE")]
    public EAbilityType AbilityType { get; set; }
    
    [NotMapped]
    public Ability Ability { get; set; }
}