using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("CHANGE_VALUE_EVENTS_BT")]
public abstract class AChangeValueEvent : AEvent
{
    [Required]
    [Column("AMOUNT")]
    public int Amount { get; set; }
}