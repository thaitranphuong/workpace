using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTOs
{
    public class StudentDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public int classroomId { get; set; }
        public virtual ClassroomDTO Classroom { get; set; }
    }
}
