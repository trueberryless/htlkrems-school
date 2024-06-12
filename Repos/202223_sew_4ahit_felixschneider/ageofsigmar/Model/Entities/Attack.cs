using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("ATTACKS")]
public class Attack {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ATTACK_ID")]
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Column("IDENTIFIER")]
    public string Identifier { get; set; }

    [Required]
    [Column("ATTACK_TYPE")]
    public EAttackType AttackType { get; set; }

    [Required, Range(0, 20)]
    [Column("DAMAGE")]
    public int Damage { get; set; }

    
    public Creature Creature { get; set; }
    
    [Column("CREATURE_ID")]
    public int CreatureId { get; set; }
    
}