using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Facilities; 

public class Institute : AFacility {

    public Faculty Faculty { get; set; }

    [Column("FACULTY_ID")]
    public int FacultyId { get; set; }
    
}