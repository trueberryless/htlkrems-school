using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Projects; 

[Table("RESEARCH_FUNDING_PROJECTS")]
public class ResearchFundingProject : AProject {
    
    [Required]
    [Column("IS_EU_SPONSORED")]
    public bool IsEuSponsored { get; set; }

    [Required]
    [Column("IS_FFG_SPONSORED")]
    public bool IsFFGSponsored { get; set; }

    [Required]
    [Column("IS_FWF_SPONSORED")]
    public bool IsFWFSponsored { get; set; }
    
}