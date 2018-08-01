                          
namespace PolyStone.CustomDomain.Communities.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="CommunityAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class CommunityAppPermissions
    {
      

        /// <summary>
        /// 圈子信息表管理权限
        /// </summary>
        public const string Community = "Pages.Community";

	 

		/// <summary>
        /// 圈子信息表创建权限
        /// </summary>
        public const string Community_CreateCommunity = "Pages.Community.CreateCommunity";
		/// <summary>
        /// 圈子信息表修改权限
        /// </summary>
        public const string Community_EditCommunity = "Pages.Community.EditCommunity";
		/// <summary>
        /// 圈子信息表删除权限
        /// </summary>
        public const string Community_DeleteCommunity = "Pages.Community.DeleteCommunity";
    }
	
}

