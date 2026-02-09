using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Center.data.Models.CourseModel;
using Training_Center.data.Models.StudentModels;
using TrainingSystem.data.Models.StudentCourse;
using TrainingSystem.Shared.Dtos.CourseDto;
using TrainingSystem.Shared.Dtos.StudentDto;

namespace TrainingSystem.Service.MappingProfile
{
    public class MainProfile:Profile
    {

        public MainProfile()
        {

            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<Student, GetStudentwithotcourseDto>().ReverseMap();

            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Course, GetCourseDto>().ReverseMap();
            CreateMap<StudentCourse, StudentCoursesDto>()
                .ForMember(d => d.StudentName, o => o.MapFrom(s => s.Student.Name))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.Course.Name));


        }
    }
}
