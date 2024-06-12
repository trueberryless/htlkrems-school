using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("CREATURE_HAS_TRAITS_JT")]
public class TraitItem {

    public Creature Creature { get; set; }

    [Column("CREATURE_ID")]
    public int CreatureId { get; set; }

    public Trait Trait { get; set; }

    [Column("TRAIT_ID")]
    public int TraitId { get; set; }
    
}