using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment.Pages
{
    public class DeleteCommentModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public DeleteCommentModel(Assignment.Models.CinemaDBContext _context)
        {

            context = _context;

        }

        public Rate rate { get; set; }
        public IActionResult OnGet(int? pid,int? mid)
        {
            if (pid == null)
            {
                NotFound();
            }

            rate = context.Rates.Find(pid,mid);

            if (rate != null)
            {
                context.Rates.Remove(rate);
                context.SaveChanges();
                return Redirect($"/MovieDetail?mid={mid}");
            }
            return Page();   
        }
    }
}
