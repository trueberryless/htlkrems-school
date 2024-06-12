using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("PROJECT_HAS_STATES_JT")]
public class ProjectStateItem {

    public AProject Project { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    public ProjectState State { get; set; }

    [Column("PROJECT_STATE")]
    public string StateCode { get; set; }

    [Column("STATE_CHANGED_AT")]
    public DateTime StateChangedAt { get; set; }
}