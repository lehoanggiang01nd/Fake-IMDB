using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Image { get; set; }
        public int? GernesId { get; set; }

        public virtual Genre Gernes { get; set; }
    }
}
