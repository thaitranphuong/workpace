using API.Models;
using API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        private readonly IConfiguration _configuration;

        public StudentController(MyDbContext myDbContext, IConfiguration configuration)
        {
            _myDbContext = myDbContext;
            _configuration = configuration;

        }

        [HttpGet]
        [Route("get-all")]
        [Authorize]
        public async Task<ActionResult<List<StudentDTO>>> GetAll()
        {
            var students = _myDbContext.Students.ToList();
            var dtos = new List<StudentDTO>();
            foreach (var student in students)
            {
                dtos.Add(new StudentDTO()
                {
                    id = student.id,
                    name = student.name,
                    Classroom = new ClassroomDTO()
                    {
                        id = student.Classroom.id,
                        name = student.Classroom.name
                    }
                });
            }
            return Ok(dtos);
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<StudentDTO>> Get(int id)
        {
            var student = _myDbContext.Students.Find(id);
            var dto = new StudentDTO()
            {
                id = student.id,
                name = _configuration["BBB:CCC:0"],
                Classroom = new ClassroomDTO()
                {
                    id = student.Classroom.id,
                    name = student.Classroom.name
                }
            };
            return Ok(dto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(StudentDTO student)
        {
            _myDbContext.Students.Add(new Student()
            {
                name = student.name
            });
            _myDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(StudentDTO student)
        {
            var edit_student = _myDbContext.Students.Find(student.id);
            edit_student.name = student.name;
            edit_student.classroomId = student.classroomId;
            _myDbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = _myDbContext.Students.Find(id);
            _myDbContext.Students.Remove(student);
            _myDbContext.SaveChanges();
            return Ok();
        }
    }
}
