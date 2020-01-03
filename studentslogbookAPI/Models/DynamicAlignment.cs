using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace studentslogbookAPI.Models
{
    [Table("dynamicalignment")]
    public class Dynamicalignment
    {
        [Key]
        public int Id_Dynamic { get; set; }
        public DateTime DA_startDate { get; set; }

        public DateTime DA_endDate { get; set; }

        public string DA_description { get; set; }

        public byte[] DA_treatmentImg { get; set; }

        public string DA_videoUrl { get; set; }

        public int Student_Id_Student { get; set; }

        public bool Practice_dynamic { get; set; }



    }
}
