using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog_Project.Model
{
    public class CreateArticle
    {
        [DisplayName("عنوان مقاله")]
        [Required(ErrorMessage = "عنوان مقاله اجباری است")]
        public string Title { get; set; }

        [DisplayName("عکس مقاله")]
        [Required(ErrorMessage = "عکس مقاله اجباری است")]
        public string Picture { get; set; }

        [DisplayName("Alt عکس")]
        public string PictureAlt { get; set; }

        [DisplayName("عنوان عکس  ")]
        public string PictureTitle { get; set; }

        [DisplayName("توضیحات کوتاه")]
        [Required(ErrorMessage = "توضیحات کوتاه اجباری است")]
        public string ShortDescription { get; set; }
        [DisplayName("متن مقاله")]
        public string Body { get; set; }
    }
}
