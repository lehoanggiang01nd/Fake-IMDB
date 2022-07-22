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

namespace Assignment.Pages
{
    public class ChangePasswordDataSet
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword",ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
    public class ChangePasswordModel : PageModel
    {
        private readonly Assignment.Models.CinemaDBContext context;
        public ChangePasswordModel(Assignment.Models.CinemaDBContext _context)
        {
            context = _context;
        }
        [BindProperty]
        public ChangePasswordDataSet Change { get; set; }

        public Person person { get; set; }
        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("user") == null)
            {
                return Redirect("/Login");
            }
            else
            {
                return Page();
            }
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
               string uid = HttpContext.Session.GetString("userId");
               person = context.Persons.Where(p => p.PersonId == int.Parse(uid)).FirstOrDefault();
               if(person.Password == Change.CurrentPassword)
                {
                    PersonDAO.ChangePassword(person.PersonId,Change.NewPassword);
                    return Redirect("/UserProfile");
                }
                else
                {
                    TempData["ErrorMessage"] = "Old Password is incorect";
                    return Page();
                }

            }
            /*if (!Request.Form["oldPassword"].Equals("") && !Request.Form["newPassword"].Equals(""))
            {
                Member a = SessionHelper.GetObjectFromJson<Member>(HttpContext.Session, "user");
                if (a.Password == Request.Form["oldPassword"])
                {
                    MemberDAO.ChangePassword(a.MemberId, Request.Form["newPassword"]);
                    OnGet();
                }
            }*/
            return Page();
        }

    }
}
