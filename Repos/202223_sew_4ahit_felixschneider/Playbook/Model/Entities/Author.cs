using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("AUTHORS")]
public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("AUTHOR_ID")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column("FIRST_NAME")]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(100)]
    [Column("LAST_NAME")]
    public string LastName { get; set; }
}