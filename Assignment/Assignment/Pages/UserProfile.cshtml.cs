using System;
using System.Collections.Generic;
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
    public class UserProfileModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public UserProfileModel(Assignment.Models.CinemaDBContext _context)
        {
            context = _context;
        }
        [BindProperty]
        public Person person { get; set; }
        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("user") == null)
            {
                return Redirect("/UserLogin");
            }
            else
            {
                string uid = HttpContext.Session.GetString("userId");
                person = context.Persons.FirstOrDefault(p => p.PersonId == int.Parse(uid));
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            string uid = HttpContext.Session.GetString("userId");
            var person1 = context.Persons.FirstOrDefault(p => p.PersonId == int.Parse(uid));
            PersonDAO.UpdatePerson(int.Parse(uid), person.Fullname, person.Gender,person1.Password,(int)person1.Type,person1.Email);

            return Redirect("/UserProfile");
        }

    }
}
