                          

namespace PolyStone.CustomDomain.CommunityCategories.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="CommunityCategoryAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class CommunityCategoryAppPermissions
    {
      

        /// <summary>
        /// 圈子类别表管理权限
        /// </summary>
        public const string CommunityCategory = "Pages.CommunityCategory";

	 

		/// <summary>
        /// 圈子类别表创建权限
        /// </summary>
        public const string CommunityCategory_CreateCommunityCategory = "Pages.CommunityCategory.CreateCommunityCategory";
		/// <summary>
        /// 圈子类别表修改权限
        /// </summary>
        public const string CommunityCategory_EditCommunityCategory = "Pages.CommunityCategory.EditCommunityCategory";
		/// <summary>
        /// 圈子类别表删除权限
        /// </summary>
        public const string CommunityCategory_DeleteCommunityCategory = "Pages.CommunityCategory.DeleteCommunityCategory";
    }
	
}

