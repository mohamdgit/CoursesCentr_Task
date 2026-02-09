using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.data.Models.InstructorStudent;
using TrainingSystem.data.Models.StudentCourse;

namespace Training_Center.data.Models.StudentModels
{
    public class Student:BaseClass<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [InverseProperty("Student")]
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        [InverseProperty("Student")]
        public ICollection<InstructorStudent> InstructorStudents { get; set; } = new HashSet<InstructorStudent>();

    }
}
