using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.Shared;
using TrainingSystem.Shared.Dtos.StudentDto;

namespace TrainingSystem.abstraction.ICentreService
{
    public interface IStudentService
    {
        public Task<IEnumerable<GetStudentwithotcourseDto>> GetallStudentsAsync();
        public  IEnumerable<GetStudentDto> GetallStudentsspec(ItemsQueryParam param);


        public  Task<GetStudentwithotcourseDto> GetStudentByIdAsync(int Id);

        public  Task<int> AddStudentAsync(AddStudentDto studentdto);
        public  Task<int> UpdateStudentAsync(UpdateStudentDto dto);
        public Task<int> deleteStudentAsync(int Id);
            
    }
}
