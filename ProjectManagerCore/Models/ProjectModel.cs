namespace ProjectManagerCore.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserModel> Users { get; set; }
        public List<ProjectUserRole> ProjectUsers { get; set; }
    }
}
