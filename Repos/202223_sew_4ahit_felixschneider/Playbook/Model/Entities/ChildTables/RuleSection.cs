using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("RULE_SECTIONS")]
public class RuleSection : ASection
{
    [Required]
    [Column("SECTION_TYPE")]
    public ERuleSectionType SectionType { get; set; }
}