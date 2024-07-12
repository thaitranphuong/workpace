using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Models;
using System;
using System.Threading.Tasks;

namespace MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public ClassroomController(MongoDBContext context)
        {
            _context = context;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Classrooms.Find(_ => true).ToListAsync();
            return Ok(result);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(Classroom model)
        {
            model.ClassroomId = Guid.NewGuid().ToString();
            await _context.Classrooms.InsertOneAsync(model);
            return Ok(model);
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(Classroom model)
        {
            var filter = Builders<Classroom>.Filter.Eq(c => c.ClassroomId, model.ClassroomId);
            var update = Builders<Classroom>.Update
                                            .Set(c => c.ClassName, model.ClassName)
                                            .Set(c => c.Quantity, model.Quantity);

            await _context.Classrooms.UpdateOneAsync(filter, update);
            return Ok(model);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _context.Classrooms.DeleteOneAsync(m => m.ClassroomId == id);
            return Ok();
        }
    }
}
