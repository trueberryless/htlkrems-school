using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("SKILLS")]
public class Skill {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SKILL_ID")]
    public int Id { get; set; }

    [Required, StringLength(50)]
    [Column("IDENTIFIER")]
    public string Identifier { get; set; }

    [Required, Range(0, 10)]
    [Column("SKILL_VALUE")]
    public int Value { get; set; }
    
}