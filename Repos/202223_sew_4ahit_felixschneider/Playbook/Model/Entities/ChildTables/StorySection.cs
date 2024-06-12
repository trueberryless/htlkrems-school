using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("STORY_SECTIONS")]
public class StorySection : ASection
{
    [Required]
    [Column("SECTION_NR")]
    public int SectionNr { get; set; }
    
    [Required]
    [Column("REGION_ID")]
    public int RegionId { get; set; }
    
    public ARegion ARegion { get; set; }
}