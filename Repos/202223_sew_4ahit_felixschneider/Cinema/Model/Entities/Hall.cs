using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("HALLS")]
public class Hall
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("HALL_ID")]
    public int Id { get; set; }

    [Required]
    [Column("CAPACITY")]
    [Range(0, 500)]
    public int Capacity { get; set; }

    [Required]
    [Column("NAME"), StringLength(45)]
    public string Name { get; set; }

    [Required]
    [Column("CODE"), StringLength(45)]
    public string Code { get; set; }

    [Required]
    [Column("CINEMA_ID")]
    public int CinemaId { get; set; }
    
    [NotMapped]
    public Cinema Cinema { get; set; }
}