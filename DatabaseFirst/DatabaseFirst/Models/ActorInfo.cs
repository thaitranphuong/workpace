﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class ActorInfo
    {
        public ushort ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FilmInfo { get; set; }
    }
}
