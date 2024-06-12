using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("E_SUBPROJECT_STATES")]
public class SubprojectState {
    [Key, Column("LABEL")]
    public string Label { get; set; }
}