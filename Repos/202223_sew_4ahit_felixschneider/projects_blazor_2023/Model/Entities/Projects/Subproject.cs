using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Facilities;

namespace Model.Entities.Projects; 

[Table("SUBPROJECTS")]
public class Subproject {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SUBPROJECT_ID")]
    public int Id { get; set; }

    [Column("DESCRIPTION"), DataType(DataType.Text)]
    public string Description { get; set; }

    [Required, Range(0, 100)]
    [Column("APPLIED_RESEARCH")]
    public int AppliedResearch { get; set; }

    [Required, Range(0, 100)]
    [Column("THEORETICAL_RESEARCH")]
    public int TheoreticalResearch { get; set; }

    [Required, Range(0,100)]
    [Column("FOCUS_RESEARCH")]
    public int FocusResearch { get; set; }

    public AProject Project { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    public Institute Institute { get; set; }

    [Column("INSTITUTE_ID")]
    public int InstituteId { get; set; }
}