                          

namespace PolyStone.CustomDomain.Regions.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="RegionAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class RegionAppPermissions
    {
      

        /// <summary>
        /// 地区表管理权限
        /// </summary>
        public const string Region = "Pages.Region";

	 

		/// <summary>
        /// 地区表创建权限
        /// </summary>
        public const string Region_CreateRegion = "Pages.Region.CreateRegion";
		/// <summary>
        /// 地区表修改权限
        /// </summary>
        public const string Region_EditRegion = "Pages.Region.EditRegion";
		/// <summary>
        /// 地区表删除权限
        /// </summary>
        public const string Region_DeleteRegion = "Pages.Region.DeleteRegion";
    }
	
}

