using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("TRAITS")]
public class Trait {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("TRAIT_ID")]
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Column("IDENTIFIER")]
    public string Identifier { get; set; }

    [Required, DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    
}