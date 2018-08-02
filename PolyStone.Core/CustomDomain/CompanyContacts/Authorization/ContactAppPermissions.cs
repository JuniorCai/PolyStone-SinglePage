                          

namespace PolyStone.CustomDomain.CompanyContacts.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="ContactAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class ContactAppPermissions
    {
      

        /// <summary>
        /// 企业联系表管理权限
        /// </summary>
        public const string Contact = "Pages.Contact";

		/// <summary>
        /// 企业联系表创建权限
        /// </summary>
        public const string Contact_CreateContact = "Pages.Contact.CreateContact";
		/// <summary>
        /// 企业联系表修改权限
        /// </summary>
        public const string Contact_EditContact = "Pages.Contact.EditContact";
		/// <summary>
        /// 企业联系表删除权限
        /// </summary>
        public const string Contact_DeleteContact = "Pages.Contact.DeleteContact";
    }
	
}

