using Abp.Authorization;
using FlexCMS.Authorization.Roles;
using FlexCMS.Authorization.Users;

namespace FlexCMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
