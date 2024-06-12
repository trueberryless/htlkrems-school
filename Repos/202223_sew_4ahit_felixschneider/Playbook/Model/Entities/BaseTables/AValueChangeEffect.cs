using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("VALUE_CHANGE_EFFECTS_BT")]
public abstract class AValueChangeEffect : AEffect
{
    [Required]
    [Column("AMOUNT")]
    public int Amount { get; set; }

    [Required]
    [Column("DURATION")]
    public int Duration { get; set; }
}