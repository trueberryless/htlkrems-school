using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("RANDOM_OUTCOMES")]
public class RandomOutcome : AOutcome
{
    [Required]
    [Column("MIN")]
    public int Min { get; set; }
    
    [Required]
    [Column("MAX")]
    public int Max { get; set; }
}