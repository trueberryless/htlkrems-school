using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Model.Entities;

[Table("BOOKS")]
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BOOK_ID")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column("TITLE")]
    public string Title { get; set; }
    
    [Required]
    [DataType(DataType.Url)]
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
}