using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("MOVIES")]
public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MOVIE_ID")]
    public int Id { get; set; }
    
    [Required]
    [Column("NAME"), StringLength(45)]
    public string Name { get; set; }

    [Required]
    [Column("DURATION")]
    [Range(0,500)]
    public int Duration { get; set; }

    [Required]
    [Column("DESCRIPTION"), DataType(DataType.Text)]
    public string Description { get; set; }

    [Required]
    [Column("SHORT_DESCRIPTION"), StringLength(255)]
    public string ShortDescription { get; set; }
}