                          
namespace PolyStone.CustomDomain.Modules.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ModuleAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class ModuleAppPermissions
    {


        /// <summary>
        /// 模块表管理权限
        /// </summary>
        public const string Module = "Pages.Module";



        /// <summary>
        /// 模块表创建权限
        /// </summary>
        public const string Module_CreateModule = "Pages.Module.CreateModule";

        /// <summary>
        /// 模块表修改权限
        /// </summary>
        public const string Module_EditModule = "Pages.Module.EditModule";

        /// <summary>
        /// 模块表删除权限
        /// </summary>
        public const string Module_DeleteModule = "Pages.Module.DeleteModule";
    }
}

