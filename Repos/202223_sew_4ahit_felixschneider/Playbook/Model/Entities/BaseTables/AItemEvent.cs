using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ITEM_EVENTS_BT")]
public abstract class AItemEvent : AEvent
{
    [Required]
    [Column("ITEM_ID")]
    public int ItemId { get; set; }
    
    [NotMapped]
    public Item Item { get; set; }
}