using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog_Project.Model
{
    public class CreateUser
    {
        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage = "نام و نام خانوادگی اجباری است")]
        public string UserName { get; set; }

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "ایمیل اجباری است")]
        public string Email { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "رمز عبور اجباری است")]
        public string Password { get; set; }
    }
}
