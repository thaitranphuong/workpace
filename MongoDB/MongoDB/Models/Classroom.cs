using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Models
{
    public class Classroom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ClassroomId { get; set; }

        [BsonElement("Name")]
        public string ClassName { get; set; }

        public int Quantity { get; set; }

        public List<Student> Students { get; set; }
    }
}
