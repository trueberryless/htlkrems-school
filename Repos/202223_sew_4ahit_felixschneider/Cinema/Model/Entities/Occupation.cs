using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("OCCUPATIONS_JT")]
public class Occupation
{
    [Column("MOVIE_ID")]
    public int MovieId { get; set; }

    [NotMapped]
    public Movie Movie { get; set; }

    [Column("PERSON_ID")]
    public int PersonId { get; set; }

    [NotMapped]
    public Person Person { get; set; }

    [Column("ROLE", TypeName = "VARCHAR(255)")]
    public EOccupationType Role { get; set; }

    [Column("OCCUPATION_BEGIN", TypeName = "DATETIME(6)")]
    public DateTime OccupationBegin { get; set; }
    
    [Required]
    [Column("OCCUPATION_END", TypeName = "DATETIME(6)")]
    public DateTime OccupationEnd { get; set; }
}