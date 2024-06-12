using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Model.Entities;

[Table("BOOK_HAS_AUTHORS_JT")]
public class Occupation
{
    [Required]
    [Column("BOOK_ID")]
    public int BookId { get; set; }
    
    [NotMapped]
    public Book Book { get; set; }
    
    [Required]
    [Column("AUTHOR_ID")]
    public int AuthorId { get; set; }
    
    [NotMapped]
    public Author Author { get; set; }
    
    [Required]
    [Column("OCCUPATION_TYPE")]
    public EOccupationType OccupationType { get; set; }
}