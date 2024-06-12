using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Debitors; 

[Table("DEBITORS")]
public class Debitor {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("DEBITOR_ID")]
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }

    [Required, StringLength(20)]
    [Column("NAME")]
    public string Name { get; set; }
    
}