using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("IMAGE_DECORATORS")]
public class ImageDecorator
{
    [Key]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
    
    [Required]
    [Column("SECTION_ID")]
    public int SectionId { get; set; }
    
    [NotMapped]
    public ASection Section { get; set; }
}