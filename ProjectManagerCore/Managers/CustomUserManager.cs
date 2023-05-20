using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectManagerCore.Models;

namespace ProjectManagerCore.Managers;

public class CustomUserManager : UserManager<UserModel>
{
    private readonly UserStore<UserModel, RoleModel, IdentityDbContext
        <UserModel, RoleModel, int,
            IdentityUserClaim<int>, ProjectUserRole, IdentityUserLogin<int>,
            IdentityRoleClaim<int>, IdentityUserToken<int>>, int, IdentityUserClaim<int>,
        IdentityUserRole<int>, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>> _store;

    public CustomUserManager(
        IUserStore<UserModel> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<UserModel> passwordHasher,
        IEnumerable<IUserValidator<UserModel>> userValidators,
        IEnumerable<IPasswordValidator<UserModel>> passwordValidators,
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
        IServiceProvider services, ILogger<UserManager<UserModel>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
            services, logger)
    {
        _store = store as UserStore<UserModel, RoleModel, IdentityDbContext
                     <UserModel, RoleModel, int,
                         IdentityUserClaim<int>, ProjectUserRole, IdentityUserLogin<int>,
                         IdentityRoleClaim<int>, IdentityUserToken<int>>, int, IdentityUserClaim<int>,
                     IdentityUserRole<int>, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>> ??
                 throw new InvalidOperationException();
    }

    public void AddProjectRole(UserModel user, ProjectModel project, RoleModel role)
    {
        _store.Context.UserRoles.Add(new ProjectUserRole
        {
            Project = project,
            ProjectId = project.Id,
            UserId = user.Id,
            RoleId = role.Id
        });
        _store.Context.SaveChanges();
    }
}