using System.ComponentModel.DataAnnotations;

namespace ProjectManagerWebApp.Models;

public class LoginViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}