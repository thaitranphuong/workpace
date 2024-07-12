using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public StudentController(MongoDBContext context)
        {
            _context = context;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            var filter = Builders<Classroom>.Filter.Eq(c => c.ClassroomId, model.ClassroomId);
            var update = Builders<Classroom>.Update.Push(c => c.Students, model);

            await _context.Classrooms.UpdateOneAsync(filter, update);
            return Ok(model);
        }
    }
}
