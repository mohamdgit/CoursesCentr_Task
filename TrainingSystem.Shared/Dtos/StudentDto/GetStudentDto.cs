using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.Shared.Dtos.CourseDto;

namespace TrainingSystem.Shared.Dtos.StudentDto
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Courses { get; set; } = new();

        public List<string> instructors { get; set; } = new();
    }
}
