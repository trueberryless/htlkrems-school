using System.Text.Json.Serialization;
using Model.Entities.Authentication;

namespace Model.Entities.Todos;

[Table("TODOS")]
public class Todo
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("TODO_ID")]
    public int Id { get; set; }
    
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("COMPLETED")]
    public bool Completed { get; set; }
    
    [JsonIgnore]
    [Column("USER_ID")] 
    public int UserId { get; set; }
    
    [JsonIgnore]
    public User User { get; set; } = null!;
}