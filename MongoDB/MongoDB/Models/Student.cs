using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Models
{
    public class Student
    { 
        public string StudentName { get; set; }

        public int Age { get; set; }

        public string ClassroomId { get; set; }
    }
}
