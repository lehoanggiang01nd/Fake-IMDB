using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment.Pages
{
    public class loginDataSet
    {
        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
    public class UserLoginModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public UserLoginModel(Assignment.Models.CinemaDBContext _context)
        {

            context = _context;

        }
        [BindProperty]
        public loginDataSet LoginDataSet { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = context.Persons.SingleOrDefault(i => i.Email == LoginDataSet.username && i.Password == LoginDataSet.password);
                if (user != null)
                {
                    HttpContext.Session.SetString("user", user.Email);
                    HttpContext.Session.SetString("userId", user.PersonId.ToString());
                    HttpContext.Session.SetString("type", user.Type.ToString());
                    return RedirectToPage("/Home");
                }
                else
                {
                    TempData["ErrorMes"] = "Username or password is incorect";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
