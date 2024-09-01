using Microsoft.AspNetCore.Identity;

namespace practice_web_apis.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
    }
}
