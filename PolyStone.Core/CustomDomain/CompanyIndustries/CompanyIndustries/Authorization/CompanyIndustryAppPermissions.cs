                          

namespace PolyStone.CustomDomain.CompanyIndustries.CompanyIndustries.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="CompanyIndustryAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class CompanyIndustryAppPermissions
    {
      

        /// <summary>
        /// 企业行业关系表管理权限
        /// </summary>
        public const string CompanyIndustry = "Pages.CompanyIndustry";

	 

		/// <summary>
        /// 企业行业关系表创建权限
        /// </summary>
        public const string CompanyIndustry_CreateCompanyIndustry = "Pages.CompanyIndustry.CreateCompanyIndustry";
		/// <summary>
        /// 企业行业关系表修改权限
        /// </summary>
        public const string CompanyIndustry_EditCompanyIndustry = "Pages.CompanyIndustry.EditCompanyIndustry";
		/// <summary>
        /// 企业行业关系表删除权限
        /// </summary>
        public const string CompanyIndustry_DeleteCompanyIndustry = "Pages.CompanyIndustry.DeleteCompanyIndustry";
    }
	
}

