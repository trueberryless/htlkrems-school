using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities; 

[Table("CREATURES")]
public class Creature {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CREATURE_ID")]
    public int Id { get; set; }

    [Required, StringLength(50)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Required, Range(0, 10)]
    [Column("BODY")]
    public int Body { get; set; }
    
    [Required, Range(0, 10)]
    [Column("MIND")]
    public int Mind { get; set; }
    
    [Required, Range(0, 10)]
    [Column("SOUL")]
    public int Soul { get; set; }
    
    [Required, Range(0, 6)]
    [Column("ARMOUR")]
    public int Armour { get; set; }

    [Required, Range(0, 50)]
    [Column("TOUGNESS")]
    public int Toughness { get; set; }

    [Required, Range(0, 20)]
    [Column("WOUNDS")]
    public int Wounds { get; set; }
    
    [Required, Range(0, 6)]
    [Column("METTLE")]
    public int Mettle { get; set; }
    
    [Required, Range(0, 20)]
    [Column("INITIATIVE")]
    public int Initiative { get; set; }
    
    [Required, Range(0, 6)]
    [Column("AWARENESS")]
    public int Awareness { get; set; }

    [Required, DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    
}