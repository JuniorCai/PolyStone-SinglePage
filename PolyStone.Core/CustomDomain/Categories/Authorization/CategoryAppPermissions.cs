                          

namespace PolyStone.CustomDomain.Categories.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CategoryAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class CategoryAppPermissions
    {


        /// <summary>
        /// 产品类目管理权限
        /// </summary>
        public const string Category = "Pages.Category";



        /// <summary>
        /// 产品类目创建权限
        /// </summary>
        public const string Category_CreateCategory = "Pages.Category.CreateCategory";

        /// <summary>
        /// 产品类目修改权限
        /// </summary>
        public const string Category_EditCategory = "Pages.Category.EditCategory";

        /// <summary>
        /// 产品类目删除权限
        /// </summary>
        public const string Category_DeleteCategory = "Pages.Category.DeleteCategory";
    }

}

