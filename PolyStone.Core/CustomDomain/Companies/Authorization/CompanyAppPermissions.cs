                          

namespace PolyStone.CustomDomain.Companies.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="CompanyAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class CompanyAppPermissions
    {
      

        /// <summary>
        /// 企业表管理权限
        /// </summary>
        public const string Company = "Pages.Company";

	 

		/// <summary>
        /// 企业表创建权限
        /// </summary>
        public const string Company_CreateCompany = "Pages.Company.CreateCompany";
		/// <summary>
        /// 企业表修改权限
        /// </summary>
        public const string Company_EditCompany = "Pages.Company.EditCompany";
		/// <summary>
        /// 企业表删除权限
        /// </summary>
        public const string Company_DeleteCompany = "Pages.Company.DeleteCompany";
    }
	
}

