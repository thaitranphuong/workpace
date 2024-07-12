using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTOs
{
    public class ClassroomDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<StudentDTO> Students { get; set; }
    }
}
