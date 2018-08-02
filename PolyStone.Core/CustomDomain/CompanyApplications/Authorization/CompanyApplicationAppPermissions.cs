                          

namespace PolyStone.CustomDomain.CompanyApplications.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="CompanyApplicationAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class CompanyApplicationAppPermissions
    {
      

        /// <summary>
        /// 个人会员升级企业申请表管理权限
        /// </summary>
        public const string CompanyApplication = "Pages.CompanyApplication";

	 

		/// <summary>
        /// 个人会员升级企业申请表创建权限
        /// </summary>
        public const string CompanyApplication_CreateCompanyApplication = "Pages.CompanyApplication.CreateCompanyApplication";
		/// <summary>
        /// 个人会员升级企业申请表修改权限
        /// </summary>
        public const string CompanyApplication_EditCompanyApplication = "Pages.CompanyApplication.EditCompanyApplication";
		/// <summary>
        /// 个人会员升级企业申请表删除权限
        /// </summary>
        public const string CompanyApplication_DeleteCompanyApplication = "Pages.CompanyApplication.DeleteCompanyApplication";
    }
	
}

