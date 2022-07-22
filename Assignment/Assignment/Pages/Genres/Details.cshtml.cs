using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;

namespace Assignment.Pages.Genres
{
    public class DetailsModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext _context;

        public DetailsModel(Assignment.Models.CinemaDBContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genres.FirstOrDefaultAsync(m => m.GernesId == id);

            if (Genre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
