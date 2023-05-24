using System.ComponentModel.DataAnnotations;

namespace ProjectManagerWebApp.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "No value for name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "No value for email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "No value for password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string? ReturnUrl { get; set; }
}