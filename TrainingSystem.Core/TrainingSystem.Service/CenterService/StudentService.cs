using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.StudentModels;
using TrainingSystem.abstraction.ICentreService;
using TrainingSystem.data.Contracts.IUOWPattern;
using TrainingSystem.data.Exceptions;
using TrainingSystem.Service.SpecificationPattern;
using TrainingSystem.Shared;
using TrainingSystem.Shared.Dtos.CourseDto;
using TrainingSystem.Shared.Dtos.StudentDto;

namespace TrainingSystem.Service.CenterService
{
    public class StudentService : IStudentService
    {
        private readonly IUOW uow;
        private readonly IMapper map;

        public StudentService(IUOW uow,IMapper map)
        {
            this.uow = uow;
            this.map = map;
        }
        public async Task<int> AddStudentAsync(AddStudentDto studentdto)
        {
            var repo = uow.GenerateRepo<Student, int>();
            var res = map.Map<AddStudentDto, Student>(studentdto);
             await repo.AddEntityAsync(res);
            return await uow.SaveChanges();
        }

        public async Task<int> deleteStudentAsync(int Id)
        {
            var repo = uow.GenerateRepo<Student, int>();
           var student= await GetStudentByIdAsync(Id);
            if(student is null)
            {
                throw new StudentNotFoundEX(Id);
            }
            repo.Delete(Id);
            return await uow.SaveChanges();
        }

        public async Task<IEnumerable<GetStudentwithotcourseDto>> GetallStudentsAsync()
        {
            var repo = uow.GenerateRepo<Student, int>();
           var students= await repo.GetAllAsync();
            var res = map.Map<IEnumerable< Student>,IEnumerable< GetStudentwithotcourseDto>>(students);

            return res;
        }

        public  IEnumerable<GetStudentDto> GetallStudentsspec(ItemsQueryParam param)
        {

            var repo = uow.GenerateRepo<Student, int>();
            var spec = new StudentSpecification(param);

            var students =  repo.GetAllSpecification(spec);
          
            var res = students.Select(s => new GetStudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Courses = s.StudentCourses
         .Where(sc => sc.Course != null&&sc.CourseId==sc.Course.Id)
         .Select(sc => sc.Course.Name)
         .ToList(),
                instructors = s.InstructorStudents
         .Where(sc => sc.Instructor != null && sc.InstructorId == sc.InstructorId)
         .Select(sc => sc.Instructor.Name)
         .ToList()




            }).ToList();

            if (!res.Any())
            {
                throw new StudentNotFoundEXception("student you search about is not found");
            }
            else
            {
                return res;

            }
        }

        public async Task<GetStudentwithotcourseDto> GetStudentByIdAsync(int Id)
        {
            var repo = uow.GenerateRepo<Student, int>();
            var students = await repo.GetByIdAsync(Id);
            if(students is null)
            {
                throw new StudentNotFoundEX(Id);

            }
            var res = map.Map<Student, GetStudentwithotcourseDto>(students);

            return res;
        }

        public async Task<int> UpdateStudentAsync( UpdateStudentDto dto)
        {
            var repo = uow.GenerateRepo<Student, int>();
            var res = map.Map<UpdateStudentDto, Student>(dto);
           
            repo.Update(res);
            return await uow.SaveChanges();
        }

       
    }
}
