namespace SimpleBlog.Dto
{
    public class RegisterErrorResponseDto
    {
        public RegisterErrorDto? Errors { get; set; }
    }

    public class RegisterErrorDto
    {
        public List<string> Name { get; set; } = new List<string>();

        public List<string> Email { get; set; } = new List<string>();

        public List<string> Password { get; set; } = new List<string>();
    }
}
