using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Facilities; 

[Table("FACILITIES_ST")]
public abstract class AFacility {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("FACILITY_ID")]
    public int Id { get; set; }

    [Column("DESCRIPTION"), DataType(DataType.Text)]
    public string Description { get; set; }

    [Required, StringLength(7)]
    [Column("FACILITY_CODE")]
    public string  FacilityCode { get; set; }

    [Required, StringLength(100)]
    [Column("FACILITY_TITLE")]
    public string FacilityTitle { get; set; }
    
}