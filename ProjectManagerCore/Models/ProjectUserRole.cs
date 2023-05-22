using Microsoft.AspNetCore.Identity;

namespace ProjectManagerCore.Models
{
    public class ProjectUserRole : IdentityUserRole<int>
    {
        public int ProjectId { get; set; }
        public virtual ProjectModel? Project { get; set; }
    }
}
