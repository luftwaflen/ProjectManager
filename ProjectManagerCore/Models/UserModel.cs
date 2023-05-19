using Microsoft.AspNetCore.Identity;

namespace ProjectManagerCore.Models
{
    public class UserModel : IdentityUser<int>
    {
        public List<ProjectModel> Projects { get; set; }
        public List<TaskModel> AppendedTasks { get; set; }
        public List<TaskModel> ExecutedTasks { get; set; }
        public List<WorkTimeModel> WorkTimes { get; set; }
    }
}
