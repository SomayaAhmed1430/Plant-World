namespace Plant_World.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class IdentityUser
    {
    }
}
