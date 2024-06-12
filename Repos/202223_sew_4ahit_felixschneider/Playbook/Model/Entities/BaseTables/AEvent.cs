using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("EVENTS_BT")]
public abstract class AEvent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EVENT_ID")]
    public int Id { get; set; }
    
    [Required]
    [Column("SECTION_ID")]
    public int SectionId { get; set; }
    
    [NotMapped]
    public StorySection Section { get; set; }
    
    [Required]
    [Column("RANKING")]
    public int Ranking { get; set; }
}