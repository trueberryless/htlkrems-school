using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("MOVIE_CREWS")]
public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("PERSON_ID")]
    public int Id { get; set; }

    [Required]
    [Column("FIRST_NAME"), StringLength(45)]
    public string FirstName { get; set; }
    
    [Required]
    [Column("LAST_NAME"), StringLength(45)]
    public string LastName { get; set; }
}