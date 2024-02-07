using Blog_Project.Context;
using Blog_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_Project.Pages
{
    public class CreateArticleModel : PageModel
    {
        [TempData]
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }


        public CreateArticle Command { get; set; }
        private readonly DatabaseContext _context;

        public CreateArticleModel(DatabaseContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost( CreateArticle command ) 
        {
            if(ModelState.IsValid)
            {
                var article = new Article(command.Title , command.Picture , command.PictureTitle, command.PictureAlt , command.Body , command.ShortDescription);

                _context.Articles.Add(article);
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
