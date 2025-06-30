using Microsoft.AspNetCore.Identity;

namespace presupuestoBasadoAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NombreCompleto { get; set; } = string.Empty;
    }
}
