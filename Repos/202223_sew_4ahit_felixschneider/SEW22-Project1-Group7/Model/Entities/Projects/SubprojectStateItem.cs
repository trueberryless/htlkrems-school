using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("SUBPROJECT_HAS_STATES_JT")]
public class SubprojectStateItem {

    public Subproject Subproject { get; set; }

    [Column("SUBPROJECT_ID")]
    public int SubprojectId { get; set; }

    public SubprojectState SubprojectState { get; set; }

    [Column("SUBPROJECT_STATE")]
    public string StateCode { get; set; }

    [Column("STATE_CHANGED_AT")]
    public DateTime StateChangedAt { get; set; }
    
}