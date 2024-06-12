using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("CREATURES")]
public class Creature
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CREATURE_ID")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(45)]
    [Column("CREATURE_TYPE")]
    public string Type { get; set; }
    
    [Required]
    [Column("COMBAT_SKILL")]
    public int CombatSkill { get; set; }
    
    [Required]
    [Column("ENDURANCE")]
    public int Endurance { get; set; }
    
    [Required]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
}