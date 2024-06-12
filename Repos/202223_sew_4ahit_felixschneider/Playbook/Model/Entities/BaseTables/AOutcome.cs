using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("OUTCOMES_BT")]
public abstract class AOutcome
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("OUTCOME_ID")]
    public int Id { get; set; }
    
    [Required]
    [Column("ROOT_SECTION_ID")]
    public int RootSectionId { get; set; }
    
    [NotMapped]
    public ASection RootASection { get; set; }
    
    [Required]
    [Column("SECTION_ID")]
    public int SectionId { get; set; }
    
    [NotMapped]
    public ASection Section { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    [Column("CONTENT")]
    public string Content { get; set; }
}