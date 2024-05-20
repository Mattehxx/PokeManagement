using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PokeManagementDAL.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
    }
}
