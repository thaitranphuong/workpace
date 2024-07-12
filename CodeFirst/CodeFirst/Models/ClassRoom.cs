using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class ClassRoom
    {
        public int id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Tên lớp học phải từ 2 - 10 ký tự")]
        public string name { get; set; }

        public ICollection<ClassRoomStudent> ClassRoomStudents { get; set; }

        public int studentId { get; set; }
        public Student student { get; set; }

        public ICollection<Student> students { get; set; }
    }
}
