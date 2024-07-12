using DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseFirst.DTOs
{
    public class ActorViewModel
    {
        public Actor actor { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}
