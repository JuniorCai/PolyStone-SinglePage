using Abp.Authorization;
using PolyStone.Authorization.Roles;
using PolyStone.Authorization.Users;

namespace PolyStone.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
