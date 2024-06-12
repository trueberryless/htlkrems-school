using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("MANAGEMENT_PROJECTS")]
public class ManagementProject : AProject {

    [Required]
    [Column("PROJECT_END")]
    public DateTime ProjectEnd { get; set; }

    [Required]
    [Column("MANAGEMENT_DUTY")]
    public EManagementDuty ManagementDuty { get; set; }
    
}