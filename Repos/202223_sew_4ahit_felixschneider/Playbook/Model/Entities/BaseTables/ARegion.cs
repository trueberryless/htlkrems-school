using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("REGIONS_BT")]
public abstract class ARegion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("REGION_ID")]
    public int Id { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Required]
    [Column("REGION_TYPE")]
    public ERegionType RegionType { get; set; }
    
    [Column("AREA_ID")]
    public int? AreaId { get; set; }
    
    [NotMapped]
    public Area? Area { get; set; }
    
    [Required]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
}