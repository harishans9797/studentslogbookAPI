using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace studentslogbookAPI.Models
{
  [Table("entry")]
  public class Entry
  {
    [Key]
    public int Id_Entry { get; set; }
    public string PatientInitials { get; set; }

    public string PatientFullName { get; set; }

    public string Course { get; set; }

    public string Status { get; set; }

    public string Diagnosis { get; set; }

    public string Indication { get; set; }

    public bool Diabetes { get; set; }

    public string TreatmentPlan { get; set; }

    public string Material { get; set; }

    public int PatientAge { get; set; }

    public float PatientWeight { get; set; }

    public float PatientHeight { get; set; }

    public bool ASleft { get; set; }

    public bool ASRight { get; set; }

    public bool ASNonAppl { get; set; }

    public DateTime TreatmentDateStart { get; set; }

    public DateTime TreatmentDateEnd { get; set; }

    public string Supervizedby { get; set; }
    
    
    public string DeviceGroup { get; set; }
    
    public string Device { get; set; }

    public int Student_Id_Student { get; set; }

    public bool Practice { get; set; }

    public bool Male { get; set; }

    public bool Female { get; set; }

  }
}
