using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ITEMS_ST")]
public class Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ITEM_ID")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    
    [Required]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
    
    [Required]
    [Column("WEIGHT")]
    public EWeightType Weight { get; set; }
}