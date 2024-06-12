using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ITEM_HAS_EFFECTS_JT")]
public class ItemEffect
{
    [Required]
    [Column("EFFECT_ID")]
    public int EffectId { get; set; }
    
    [NotMapped]
    public AEffect Effect { get; set; }
    
    [Required]
    [Column("ITEM_ID")]
    public int ItemId { get; set; }
    
    [NotMapped]
    public Item Item { get; set; }
}