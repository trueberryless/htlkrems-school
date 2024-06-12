using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("SECTIONS_BT")]
public abstract class ASection
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SECTION_ID")]
    public int Id { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    [Column("CONTENT")]
    public string Content { get; set; }
    
    [Required]
    [Column("BOOK_ID")]
    public int BookId { get; set; }
    
    [NotMapped]
    public Book Book { get; set; }
}