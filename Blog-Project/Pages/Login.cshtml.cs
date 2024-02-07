using Blog_Project.Context;
using Blog_Project.Model;
using Blog_Project.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_Project.Pages
{
    public class LoginModel : PageModel
    {
        [TempData]
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }


        public CreateUser command { get; set; }
        private readonly DatabaseContext _context;

        public LoginModel(DatabaseContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }


        public IActionResult OnPost(CreateUser command)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(p => p.Email.Equals(command.Email));
                if (user != null)
                {
                    var passwordHasher = new PasswordHasher();
                    bool resultVerifyPassword = passwordHasher.VerifyPassword(command.Password, user.Password);
                    if (resultVerifyPassword == true)
                    {
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        ErrorMessage = "رمز عبور اشتباه است";
                        return Page();
                    }
                }
                else
                {
                    ErrorMessage = "کاربری با این مشخصات یافت نشد";
                    return Page();
                }
            }
            else
            {
                ErrorMessage = "لطفا مقادیر خواسته شده را وارد کنید";
                return Page();
            }
        }

    }
}

