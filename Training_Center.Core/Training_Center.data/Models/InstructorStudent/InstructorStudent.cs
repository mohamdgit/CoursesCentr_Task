using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.CourseModel;
using Training_Center.data.Models.InstructorModel;
using Training_Center.data.Models.StudentModels;

namespace TrainingSystem.data.Models.InstructorStudent
{
    public class InstructorStudent
    {
        public int InstructorId { get; set; }
        [InverseProperty("InstructorStudents")]
        public Instructor Instructor { get; set; }
        public int StudentId { get; set; }
        [InverseProperty("InstructorStudents")]
        public Student Student { get; set; }
    }
}
