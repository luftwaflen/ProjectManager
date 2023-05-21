﻿using System.ComponentModel.DataAnnotations;

namespace ProjectManagerWebApp.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "No data")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string? ReturnUrl { get; set; }
}