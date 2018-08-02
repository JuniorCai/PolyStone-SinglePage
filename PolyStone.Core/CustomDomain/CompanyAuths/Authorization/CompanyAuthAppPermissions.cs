                          

namespace PolyStone.CustomDomain.CompanyAuths.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="CompanyAuthAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class CompanyAuthAppPermissions
    {
      

        /// <summary>
        /// 企业资质表管理权限
        /// </summary>
        public const string CompanyAuth = "Pages.CompanyAuth";

	 

		/// <summary>
        /// 企业资质表创建权限
        /// </summary>
        public const string CompanyAuth_CreateCompanyAuth = "Pages.CompanyAuth.CreateCompanyAuth";
		/// <summary>
        /// 企业资质表修改权限
        /// </summary>
        public const string CompanyAuth_EditCompanyAuth = "Pages.CompanyAuth.EditCompanyAuth";
		/// <summary>
        /// 企业资质表删除权限
        /// </summary>
        public const string CompanyAuth_DeleteCompanyAuth = "Pages.CompanyAuth.DeleteCompanyAuth";
    }
	
}

