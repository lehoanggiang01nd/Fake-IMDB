using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Type { get; set; }
    }
}
