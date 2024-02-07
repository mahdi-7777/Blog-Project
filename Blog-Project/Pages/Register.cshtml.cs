using Azure.Core;
using Blog_Project.Context;
using Blog_Project.Model;
using Blog_Project.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_Project.Pages
{
    public class RegisterModel : PageModel
    {
        [TempData]
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }


        public CreateUser command { get; set; }
        private readonly DatabaseContext _context;

        public RegisterModel( DatabaseContext context)
        {
            
            _context = context;
        }

        public void OnGet()
        {
        }



        public IActionResult OnPost(CreateUser command)
        {
            var passwordHasher = new PasswordHasher();
            var hashedPassword = passwordHasher.HashPassword(command.Password);
            if (ModelState.IsValid)
            {
                var user = new Users(command.UserName, command.Email, hashedPassword);
                TempData["Username"] = command.UserName;

                _context.Users.Add(user);
                _context.SaveChanges();
               
                return RedirectToPage("./Index");

            }
            else
            {
                ErrorMessage = "مقادیر خواسته شده رو وارد نمایید ";
                return Page();
            }

        }
    }
}
