using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("PLAYER_LEVELS")]
public class PlayerLevel
{
    [Key]
    [Column("PLAYER_LEVEL", TypeName = "VARCHAR(50)")]
    public EPlayerLevel Level { get; set; }
    
    [Required]
    [Column("ABILITY_COUNT")]
    public int AbilityCount { get; set; }
    
    [Required]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
}
    