using Microsoft.AspNetCore.Identity;

namespace ProjectManagerCore.Models
{
    public class UserModel : IdentityUser<int>
    {
        public virtual List<ProjectModel> Projects { get; set; }
        public virtual List<TaskModel> AppendedTasks { get; set; }
        public virtual List<TaskModel> ExecutedTasks { get; set; }
        public virtual List<WorkTimeModel> WorkTimes { get; set; }
    }
}
