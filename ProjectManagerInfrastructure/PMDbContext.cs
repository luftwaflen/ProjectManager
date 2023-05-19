using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;

namespace ProjectManagerInfrastructure
{
    public class PMDbContext : IdentityDbContext
    <UserModel, RoleModel, int,
        IdentityUserClaim<int>, ProjectUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        DbSet<ProjectModel> Projects { get; set; }
        DbSet<TaskModel> Tasks { get; set; }
        DbSet<WorkTimeModel> WorkTimes { get; set; }

        public PMDbContext(DbContextOptions<PMDbContext> options) :
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkTimeModel>()
                .HasOne(t => t.Task)
                .WithOne(t => t.WorkTime)
                .HasForeignKey<WorkTimeModel>("TaskId");

            modelBuilder.Entity<WorkTimeModel>()
                .HasOne(w => w.User)
                .WithMany(w => w.WorkTimes);

            modelBuilder.Entity<TaskModel>()
                .HasOne(u => u.Appender)
                .WithMany(u => u.AppendedTasks);

            modelBuilder.Entity<TaskModel>()
                .HasOne(u => u.Executor)
                .WithMany(u => u.ExecutedTasks);

            modelBuilder
                .Entity<ProjectModel>()
                .HasMany(c => c.Users)
                .WithMany(s => s.Projects)
                .UsingEntity<ProjectUserRole>();

            modelBuilder.Entity<ProjectUserRole>()
                .HasOne<UserModel>()
                .WithMany()
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<ProjectUserRole>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<ProjectUserRole>()
                .HasKey(t => new { t.ProjectId, t.UserId, t.RoleId });

            modelBuilder.Entity<ProjectUserRole>().ToTable("ProjectUserRoles");

            modelBuilder.Entity<ProjectUserRole>()
                .HasOne<RoleModel>()
                .WithMany()
                .HasForeignKey(pt => pt.RoleId);
        }
    }
}
