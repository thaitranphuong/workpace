﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class FilmActor
    {
        public ushort ActorId { get; set; }
        public ushort FilmId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }
}
