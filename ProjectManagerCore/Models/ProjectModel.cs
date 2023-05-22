namespace ProjectManagerCore.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<UserModel> Users { get; set; }
        public virtual List<ProjectUserRole> ProjectUsers { get; set; }
        public virtual List<TaskModel> Tasks { get; set; }
    }
}
