using Blog_Project.Context;
using Blog_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_Project.Pages
{
    public class ArticleDetailModel : PageModel
    {
        public ArticleViewModel Article { get; set; }


        private readonly DatabaseContext _context;

        public ArticleDetailModel(DatabaseContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            Article = _context.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Body = x.Body,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
