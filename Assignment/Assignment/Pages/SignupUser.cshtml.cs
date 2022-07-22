using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment.Pages
{
    public class SignupSetData
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string email { get; set; }

        [Display(Name = "fullname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "fullname is required")]
        public string fullname { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "RePassword")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Re-Password is required")]
        [Compare("password", ErrorMessage = "Re-Password and Password do not match")]
        public string repassword { get; set; }

        [Display(Name = "Gender")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required")]
        public string gender { get; set; }
    }
    public class SignupUserModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public SignupUserModel(Assignment.Models.CinemaDBContext _context)
        {

            context = _context;

        } 

        [BindProperty]
        public SignupSetData SignupSetData { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var person = PersonDAO.getCustomerByEmail(SignupSetData.email);
                if(person == null)
                {
                    PersonDAO.Signup(SignupSetData.email, SignupSetData.fullname, SignupSetData.password, SignupSetData.gender,2);
                    return Redirect("/UserLogin");
                }
                else
                {
                    TempData["ErrorMes"] = "This Email already exist";
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
