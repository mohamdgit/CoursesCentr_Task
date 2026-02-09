using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.CourseModel;
using TrainingSystem.data.Models.InstructorStudent;

namespace Training_Center.data.Models.InstructorModel
{
    public class Instructor:BaseClass<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
         [Phone]
        public string PhoneNumber { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        [InverseProperty("CourseInstructors")]
        public Course Course { get; set; }
        [InverseProperty("Instructor")]
        public ICollection<InstructorStudent> InstructorStudents { get; set; } = new HashSet<InstructorStudent>();

    }
}
