using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ADDRESSES")]
public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto-increment
    [Column("ADDRESS_ID")]
    public int Id { get; set; }

    [Required]
    [Column("POSTAL_CODE"), StringLength(8)]
    public string PostalCode { get; set; }

    [Required]
    [Column("LOCATION"), StringLength(100)]
    public string Location { get; set; }

    [Required]
    [Column("STREET"), StringLength(100)]
    public string Street { get; set; }

    [Required]
    [Column("COUNTRY")]
    public string CountryName { get; set; }
    
    [NotMapped]
    public Country Country { get; set; }

    [Required]
    [Column("STATE")]
    public string StateCode { get; set; }
    
    [NotMapped]
    public State State { get; set; }

    public override string ToString()
    {
        return $"{PostalCode} {Location} - {Street}";
    }
}