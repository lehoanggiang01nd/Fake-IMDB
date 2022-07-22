using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment.Models;
using Assignment.Security;
using Assignment.Models.DAO;

namespace Assignment.Pages.Persons
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
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string EncrytPassword = SecurityString.GetHash(Person.Password);
            PersonDAO.Signup(Person.Email, Person.Fullname, EncrytPassword, Person.Gender,(int)Person.Type);
            /*_context.Persons.Add(Person);
            await _context.SaveChangesAsync();*/

            return RedirectToPage("./Index");
        }
    }
}
