namespace PolyStone.CustomDomain.UserAuthorizations.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="UserAuthorizationAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class UserAuthorizationAppPermissions
    {
        
        /// <summary>
        /// 用户第三方绑定管理权限
        /// </summary>
        public const string UserAuthorization = "Pages.UserAuthorization";



        /// <summary>
        /// 用户第三方绑定创建权限
        /// </summary>
        public const string UserAuthorization_CreateUserAuthorization =
            "Pages.UserAuthorization.CreateUserAuthorization";

        /// <summary>
        /// 用户第三方绑定修改权限
        /// </summary>
        public const string UserAuthorization_EditUserAuthorization = "Pages.UserAuthorization.EditUserAuthorization";

        /// <summary>
        /// 用户第三方绑定删除权限
        /// </summary>
        public const string UserAuthorization_DeleteUserAuthorization =
            "Pages.UserAuthorization.DeleteUserAuthorization";
    }
}

