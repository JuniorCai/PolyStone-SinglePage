                          

namespace PolyStone.CustomDomain.Members.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="MemberAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class MemberAppPermissions
    {


        /// <summary>
        /// 个人会员信息表管理权限
        /// </summary>
        public const string Member = "Pages.Member";



        /// <summary>
        /// 个人会员信息表创建权限
        /// </summary>
        public const string Member_CreateMember = "Pages.Member.CreateMember";

        /// <summary>
        /// 个人会员信息表修改权限
        /// </summary>
        public const string Member_EditMember = "Pages.Member.EditMember";

        /// <summary>
        /// 个人会员信息表删除权限
        /// </summary>
        public const string Member_DeleteMember = "Pages.Member.DeleteMember";
    }

}

