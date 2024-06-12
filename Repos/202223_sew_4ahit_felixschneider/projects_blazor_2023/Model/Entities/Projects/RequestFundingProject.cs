using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("REQUEST_FUNDING_PROJECTS")]
public class RequestFundingProject : AProject{

    [Required]
    [Column("IS_SMALL_PROJECT")]
    public bool IsSmallProject { get; set; }
    
}