﻿using System.ComponentModel.DataAnnotations;

namespace ProjectManagerWebApp.Models;

public class RegisterViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string RepeatPassword { get; set; }
}