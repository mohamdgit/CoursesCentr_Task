using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.InstructorModel;
using TrainingSystem.data.Models.StudentCourse;

namespace Training_Center.data.Models.CourseModel
{
    public class Course:BaseClass<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int hours { get; set; }
        [InverseProperty("Course")]
        public ICollection<Instructor> CourseInstructors { get; set; } = new HashSet<Instructor>();
        [InverseProperty("Course")]
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
