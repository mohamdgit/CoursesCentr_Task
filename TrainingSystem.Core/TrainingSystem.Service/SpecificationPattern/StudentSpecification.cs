using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.StudentModels;
using TrainingSystem.Shared;

namespace TrainingSystem.Service.SpecificationPattern
{
    public class StudentSpecification : BaseSpecification<Student, int>
    {

        public StudentSpecification(ItemsQueryParam? param)
          : base
            (
                p => (param == null )||((!param.Id.HasValue || p.Id == param.Id) &&
                (string.IsNullOrEmpty(param.Phone) || p.PhoneNumber.ToLower().Contains(param.Phone.ToLower())) &&
                (string.IsNullOrEmpty(param.Name) || p.Name.ToLower().Contains(param.Name.ToLower()))
                )
            )
        {
            OrderByAscFun(p => p.Name);

            Addincludesfunc(p => p.InstructorStudents);
            
            Addincludesfunc(p => p.StudentCourses);
        }
    }
}
