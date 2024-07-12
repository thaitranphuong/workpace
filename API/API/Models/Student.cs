using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }

        public int classroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
