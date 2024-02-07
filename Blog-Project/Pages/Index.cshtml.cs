using Blog_Project.Context;
using Blog_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_Project.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }


        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Articles = _context.Articles.Where(x => x.IsDeleted == false).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                IsDeleted=!x.IsDeleted

               
            }).OrderByDescending(x => x.Id).ToList();


        }


        public IActionResult OnGetDelete(int Id)
        {
            var articles = _context.Articles.First(x => x.Id == Id);
            articles.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}