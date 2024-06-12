using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("E_STATES")]
public class State
{
    [Key]
    [Column("NAME"), StringLength(100)]
    public string Name { get; set; }
}