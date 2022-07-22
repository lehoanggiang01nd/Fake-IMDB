using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment.Pages
{
    public class DashBoardModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public DashBoardModel(Assignment.Models.CinemaDBContext _context)
        {

            context = _context;

        }

        public int UserNumber { get; set; }
        public int CommentNumber { get; set; }
        public int RatingNumber { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("type") == "1")
            {
                UserNumber = context.Persons.Where(p => p.Type == 2).ToList().Count;
                CommentNumber = context.Rates.Where(r => r.Comment != null).ToList().Count;
                RatingNumber = context.Rates.Where(r => r.NumbericRating != null).ToList().Count;
                return Page();
            }
            else
            {
                return Redirect("/Error");
            }
           
        }
    }
}
