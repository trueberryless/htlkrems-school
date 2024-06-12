using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("PROJECTS_BT")]
public abstract class AProject {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("PROJECT_ID")]
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Column("TITLE")]
    public string Title { get; set; }
    
    [Column("DESCRIPTION"), DataType(DataType.Text)]
    public string Description { get; set; }

    [Required]
    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    public LegalFoundation LegalFoundation { get; set; }

    [Column("LEGAL_FOUNDATION")]
    public string LegalCode { get; set; }
    
}