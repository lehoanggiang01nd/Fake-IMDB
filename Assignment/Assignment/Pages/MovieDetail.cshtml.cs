using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Models.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Pages
{
    public class CommentDataSet{
        [Display(Name = "Comment")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Comment is required")]
        public string comment { get; set; }

        [Display(Name = "fullname")]
        [Required(ErrorMessage = "Rating is required")]
        public float rating { get; set; }
    }
    public class MovieDetailModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public MovieDetailModel(Assignment.Models.CinemaDBContext _context)
        {

            context = _context;

        }
        [BindProperty]
        public CommentDataSet comment { get; set; }

        public List<Rate> rate { get; set; }

        public Movie Movie { get; set; }

        public float AvarageRating { get; set; }
        public IActionResult OnGet(int? mid)
        {
            if(mid == null)
            {
                return NotFound();
            }

            Movie = context.Movies.Include(m => m.Gernes).FirstOrDefault(m => m.MovieId == mid);
            rate = context.Rates.Include(r => r.Movie).Include(r => r.Person).Where(r => r.MovieId == mid).ToList();

            var total = context.Rates.Where(r => r.MovieId == mid).Sum(r => r.NumbericRating);

            AvarageRating = (float)(total / rate.Count);


            if(Movie == null)
            {
                return NotFound();
            }
            if(rate == null)
            {
                return Page();
            }
            return Page();
        }
        public IActionResult OnPost(int? mid)
        {
            if(HttpContext.Session.GetString("user") == null)
            {                
                return Redirect("/UserLogin");
            }
            else
            {
                string uid = HttpContext.Session.GetString("userId");
                RateDAO.AddComment((int)mid,int.Parse(uid), comment.comment, comment.rating);
                OnGet(mid);
                return Page();
            }
        }
    }
}
