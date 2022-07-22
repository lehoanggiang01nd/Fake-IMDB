using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;
using Microsoft.AspNetCore.Http;

namespace Assignment.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext _context;

        public IndexModel(Assignment.Models.CinemaDBContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("type") == "1")
            {
                Genre = _context.Genres.ToList();
                return Page();
            }
            else
            {
                return Redirect("/Error");
            }
            
        }
    }
}
