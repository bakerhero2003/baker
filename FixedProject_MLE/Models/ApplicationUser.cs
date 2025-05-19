using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string FullName { get; set; }
    
    public bool IsApproved { get; set; } = false;
    
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
}