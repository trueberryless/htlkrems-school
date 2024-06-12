using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("E_PROJECT_STATES")]
public class ProjectState {

    [StringLength(12)]
    [Key]
    public string Label { get; set; }
    
}