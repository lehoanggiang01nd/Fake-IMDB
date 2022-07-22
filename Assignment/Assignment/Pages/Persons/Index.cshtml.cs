using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;
using Microsoft.AspNetCore.Http;

namespace Assignment.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext _context;

        public IndexModel(Assignment.Models.CinemaDBContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("type") == "1")
            {
                Person = _context.Persons.ToList();
                return Page();
            }
            else
            {
                return Redirect("/Error");
            }
            
        }
    }
}
