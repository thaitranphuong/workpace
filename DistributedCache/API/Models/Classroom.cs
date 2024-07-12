using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Classroom
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
