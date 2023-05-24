using System.ComponentModel.DataAnnotations;

namespace ProjectManagerWebApp.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "No value for name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "No value for email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "No value for password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "No value for password")]
    [Compare("Password", ErrorMessage = "Passwords are not same")]
    [DataType(DataType.Password)]
    public string RepeatPassword { get; set; }
}