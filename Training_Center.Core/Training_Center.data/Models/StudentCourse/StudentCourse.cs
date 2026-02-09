using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.CourseModel;
using Training_Center.data.Models.StudentModels;

namespace TrainingSystem.data.Models.StudentCourse
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        [InverseProperty("StudentCourses")]
        public Student Student { get; set; }
        public int CourseId { get; set; }
        [InverseProperty("StudentCourses")]
        public Course Course { get; set; }
    }
}
