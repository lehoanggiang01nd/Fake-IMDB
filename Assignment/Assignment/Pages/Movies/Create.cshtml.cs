using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment.Models;

namespace Assignment.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext _context;

        public CreateModel(Assignment.Models.CinemaDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GernesId"] = new SelectList(_context.Genres, "GernesId", "Descripsion");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
