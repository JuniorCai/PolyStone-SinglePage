                          
namespace PolyStone.CustomDomain.UserVerifies.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="UserVerifyAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class UserVerifyAppPermissions
    {
      

        /// <summary>
        /// 用户验证码管理权限
        /// </summary>
        public const string UserVerify = "Pages.UserVerify";

	 

		/// <summary>
        /// 用户验证码创建权限
        /// </summary>
        public const string UserVerify_CreateUserVerify = "Pages.UserVerify.CreateUserVerify";
		/// <summary>
        /// 用户验证码修改权限
        /// </summary>
        public const string UserVerify_EditUserVerify = "Pages.UserVerify.EditUserVerify";
		/// <summary>
        /// 用户验证码删除权限
        /// </summary>
        public const string UserVerify_DeleteUserVerify = "Pages.UserVerify.DeleteUserVerify";
    }
	
}

