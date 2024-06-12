using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("STORY_EVENTS")]
public class StoryEvent : AEvent
{
    [Required]
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    
    [Required]
    [StringLength(255)]
    [Column("TITLE")]
    public string Title { get; set; }
    
    [Required]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
}