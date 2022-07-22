﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int GernesId { get; set; }
        public string Descripsion { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
