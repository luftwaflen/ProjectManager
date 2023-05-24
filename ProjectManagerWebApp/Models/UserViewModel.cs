using System.ComponentModel.DataAnnotations;

namespace ProjectManagerWebApp.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public int Role { get; set; }
}