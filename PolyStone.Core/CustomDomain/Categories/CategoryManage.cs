using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.Categories
{
    /// <summary>
    /// 产品类目业务管理
    /// </summary>
    public class CategoryManage : IDomainService
    {
        private readonly IRepository<Category, int> _categoryRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CategoryManage(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //TODO:编写领域业务代码


        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {

        }

    }
}
