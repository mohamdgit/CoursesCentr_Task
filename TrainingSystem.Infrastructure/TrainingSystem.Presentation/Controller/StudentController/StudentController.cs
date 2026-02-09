using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrainingSystem.abstraction.ICentreService;
using TrainingSystem.abstraction.IServiceProviderPattern;
using TrainingSystem.Shared;
using TrainingSystem.Shared.Dtos.StudentDto;

namespace TrainingSystem.Presentation.Controller.StudentController
{
    [ApiController]
    [Route("[controller]")]
    public class Studentcontroller : ControllerBase
    {
        private readonly IServicemanager service;

        public Studentcontroller(IServicemanager service)
        {
            this.service = service;
        }
        [HttpGet("students")]
        public async Task<IActionResult> getallstudents()
        {
            var res = await service.StudentService.GetallStudentsAsync();

            return Ok(res);

        }
        [HttpGet("studentdetails")]
        public  IActionResult getstudentsdetails([FromQuery]ItemsQueryParam item)
        {
           
          var res =  service.StudentService.GetallStudentsspec(item);

            return Ok(res);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getstudentbrID(int id)
        {
            var res = await service.StudentService.GetStudentByIdAsync(id);

            return Ok(res);

        }
        [HttpPost()]
        public async Task<IActionResult> Addstudent([FromBody]AddStudentDto dto)
        {
            var res = await service.StudentService.AddStudentAsync(dto);

            return Ok(res);

        }
        [HttpPut()]
        public async Task<IActionResult> Updatestudent([FromBody] UpdateStudentDto dto)
        {
            var res = await service.StudentService.UpdateStudentAsync(dto);

            return Ok(res);

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Addstudent(int Id)
        {
            var res = await service.StudentService.deleteStudentAsync(Id);

            return Ok(res);

        }

    }
}
