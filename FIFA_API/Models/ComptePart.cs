namespace FIFA_API.Models
{
    public partial class Compte
    {
        public string UserName { get; set; }
        public string? FullName { get; set; }
        public string Password { get; set; }
        public string? UserRole { get; set; }
    }
}
