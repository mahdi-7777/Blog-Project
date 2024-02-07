namespace Blog_Project.Model
{
    public class Users
    {
        public Users(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
