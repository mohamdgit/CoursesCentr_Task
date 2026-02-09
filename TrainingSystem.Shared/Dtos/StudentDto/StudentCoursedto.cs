using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.Shared.Dtos.CourseDto;

namespace TrainingSystem.Shared.Dtos.StudentDto
{
    public class StudentCoursesDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
