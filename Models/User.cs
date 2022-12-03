namespace SimpleBlog.Models
{
    enum UserRole
    {
        Writer,
        Commenter
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordDigest { get; set; }
        public UserRole Role { get; set; }
    }
}
