using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ABILITY_HAS_EFFECTS_JT")]
public class AbilityEffect
{
    [Required]
    [Column("ABILITY_TYPE")]
    public EAbilityType AbilityType { get; set; }
    
    [NotMapped]
    public Ability Ability { get; set; }
    
    [Required]
    [Column("EFFECT_ID")]
    public int EffectId { get; set; }
    
    [NotMapped]
    public AEffect Effect { get; set; }
}