namespace PolyStone.CustomDomain.BusinessCard.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="BusinessCardAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class BusinessCardAppPermissions
    {
      

        /// <summary>
        /// 名片管理权限
        /// </summary>
        public const string BusinessCard = "Pages.BusinessCard";

	 

		/// <summary>
        /// 名片创建权限
        /// </summary>
        public const string BusinessCard_CreateBusinessCard = "Pages.BusinessCard.CreateBusinessCard";
		/// <summary>
        /// 名片修改权限
        /// </summary>
        public const string BusinessCard_EditBusinessCard = "Pages.BusinessCard.EditBusinessCard";
		/// <summary>
        /// 名片删除权限
        /// </summary>
        public const string BusinessCard_DeleteBusinessCard = "Pages.BusinessCard.DeleteBusinessCard";
    }
	
}

