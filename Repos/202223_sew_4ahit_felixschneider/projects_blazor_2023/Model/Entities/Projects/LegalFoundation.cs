using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("E_LEGAL_FOUNDATIONS")]
public class LegalFoundation {

    [Key, Column("LABEL")]
    [StringLength(4)]
    public string Label { get; set; }

    [Required, StringLength(255)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    
}