using Abp.Authorization;
using test.Authorization.Roles;
using test.Authorization.Users;

namespace test.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
