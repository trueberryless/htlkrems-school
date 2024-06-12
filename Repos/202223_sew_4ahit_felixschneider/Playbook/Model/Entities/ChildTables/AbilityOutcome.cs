using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ABILITY_OUTCOMES")]
public class AbilityOutcome : AOutcome
{
    [Required]
    [StringLength(50)]
    [Column("ABILITY_TYPE")]
    public EAbilityType AbilityType { get; set; }
    
    [NotMapped]
    public Ability Ability { get; set; }
}