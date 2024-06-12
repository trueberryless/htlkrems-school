using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("CINEMAS")]
public class Cinema
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CINEMA_ID")]
    public int Id { get; set; }

    [Required]
    [Column("LABEL"), StringLength(100)]
    public string Label { get; set; }

    [Required]
    [Column("ADDRESS_ID")]
    public int AddressId { get; set; }
    
    [NotMapped]
    public Address Address { get; set; }
}