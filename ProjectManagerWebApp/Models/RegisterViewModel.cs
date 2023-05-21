using System.ComponentModel.DataAnnotations;

namespace ProjectManagerWebApp.Models;

public class RegisterViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwords are not same")]
    [DataType(DataType.Password)]
    public string RepeatPassword { get; set; }
}