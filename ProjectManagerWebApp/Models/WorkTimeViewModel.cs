using ProjectManagerCore.Models;

namespace ProjectManagerWebApp.Models;

public class WorkTimeViewModel
{
    public int Id { get; set; }
    public UserModel User { get; set; }
    public TaskModel Task { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }
}