using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public ICollection<ClassRoomStudent> ClassRoomStudents { get; set; }


        public int classroomId { get; set; }
        public ClassRoom classRoom { get; set; }

        public ICollection<ClassRoom> classRooms { get; set; }
    }
}
