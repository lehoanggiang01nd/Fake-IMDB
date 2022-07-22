using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Pages
{
    
    public class HomeModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public HomeModel(Assignment.Models.CinemaDBContext _context)
        {

            context = _context;

        }
        public List<Movie> Movies { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTXT { get; set; }

        public IActionResult OnGet(int ?id)
        {
            Movies = MovieDAO.GetMoviesByName(SearchTXT);
            if(id != null)
            {
                Movies = context.Movies.Where(s => s.GernesId == id).ToList();
            }
            return Page();
        }
        
    }
}
