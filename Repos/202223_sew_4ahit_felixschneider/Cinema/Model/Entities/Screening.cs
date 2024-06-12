using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("SCREENINGS_JT")]
public class Screening
{
    [Column("MOVIE_ID")]
    public int MovieId { get; set; }

    public Movie Movie { get; set; }
    
    [Column("HALL_ID")]
    public int HallId { get; set; }

    public Hall Hall { get; set; }

    [Column("STARTS_AT", TypeName = "DATETIME(6)")]
    public DateTime StartsAt { get; set; }

    [Required]
    [Column("ENDS_AT", TypeName = "DATETIME(6)")]
    public DateTime EndsAt { get; set; }
}