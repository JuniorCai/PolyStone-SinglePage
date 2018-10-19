using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.Modules
{
    /// <summary>
    /// 模块表业务管理
    /// </summary>
    public class ModuleManage : IDomainService
    {
        private readonly IRepository<Module, int> _moduleRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ModuleManage(IRepository<Module, int> moduleRepository)
        {
            _moduleRepository = moduleRepository;
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
