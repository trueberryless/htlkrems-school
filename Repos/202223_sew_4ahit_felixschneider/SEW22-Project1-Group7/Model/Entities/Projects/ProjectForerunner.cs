using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("PROJECT_FORERUNNERS_JT")]
public class ProjectForerunner {

    public AProject Project { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    public AProject ParentProject { get; set; }

    [Column("PARENT_ID")]
    public int ParentProjectId { get; set; }
    
}