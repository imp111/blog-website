namespace Blog_Website.ViewModels
{
    public class LoginViewModel // ViewModel works only with the view, no database involved
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
