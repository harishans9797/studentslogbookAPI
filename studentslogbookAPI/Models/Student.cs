using RestSharp.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace studentslogbookAPI.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int Id_Student { get; set; }
        [Required]
        public string Student_Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Student_fname { get; set; }
        
        public byte[] Student_Image { get; set; }
        [Required]
        public string Student_lname { get; set; }
        [Required]
        public string Student_address { get; set; }
        [Required]
        public string Student_age { get; set; }
        public string Role { get; set; }
       
        public string Active_course { get; set; }
        
       public bool Male { get; set; }

       public bool Female { get; set; }
        
    }
}
