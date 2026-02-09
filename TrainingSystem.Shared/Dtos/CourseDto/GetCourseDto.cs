using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSystem.Shared.Dtos.CourseDto
{
    public class GetCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
    }
}
