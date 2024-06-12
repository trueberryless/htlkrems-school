using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ABILITIES")]
public class Ability
{
    [Key]
    [Column("ABILITY_TYPE")]
    public EAbilityType AbilityType { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    
    [Required]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
}