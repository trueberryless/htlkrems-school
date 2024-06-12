using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ITEM_OUTCOMES")]
public class ItemOutcome : AOutcome
{
    [Required]
    [Column("ITEM_ID")]
    public int ItemId { get; set; }
    
    [NotMapped]
    public Item Item { get; set; }
}