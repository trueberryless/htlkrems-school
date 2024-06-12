using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Model.Entities.Projects;

namespace Model.Entities.Debitors; 

[Table("PROJECT_DEBITORS_JT")]
public class ProjectDebitor {

    public AProject Project { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    public Debitor Debitor { get; set; }

    [Column("DEBITOR_ID")]
    public int DebitorId { get; set; }

    [Required, Range(0, 99999999)]
    [Column("AMOUNT"), Precision(10,2)]
    public float Amount { get; set; }

}