using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("E_COUNTRIES")]
public class Country
{
    [Key]
    [Column("NAME"), StringLength(100)]
    public string Name { get; set; }
}