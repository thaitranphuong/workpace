using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        public class Class
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ClassId { get; set; }
        }

        static void Main(string[] args)
        {
            var classes = new List<Class>
            {
                new Class { Id = 1, Name = "Class 1"},
                new Class { Id = 2, Name = "Class 2"},
                new Class { Id = 3, Name = "Class 3"},
            };

            var students = new List<Student>
            {
                new Student { Id = 1, Name = "student 1", ClassId = 1 },
                new Student { Id = 2, Name = "student 2", ClassId = 2 },
                new Student { Id = 3, Name = "student 3", ClassId = 1 },
                new Student { Id = 4, Name = "student 4", ClassId = 2 },
                new Student { Id = 5, Name = "student 5", ClassId = 1 },
                new Student { Id = 6, Name = "student 6", ClassId = 3 },
                new Student { Id = 7, Name = "student 7", ClassId = 2 },
            };

            var result = (from s in students
                          join
                            c in classes
                            on s.ClassId equals c.Id
                                          orderby s.Id descending
                                          select new
                                          {
                                              Id = s.Id,
                                              Name = s.Name,
                                              ClassName = c.Name
                                          }).Where(s => s.ClassName == "Class 3");

            foreach (var student in result)
            {
                Console.WriteLine(student.Id + ", " + student.Name + ", " + student.ClassName);
            }

            Console.ReadKey();
        }
    }
}
