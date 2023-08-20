using Microsoft.AspNetCore.Identity;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
    }
}
