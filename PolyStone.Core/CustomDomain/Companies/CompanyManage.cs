using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.Companies
{
    /// <summary>
    /// 企业表业务管理
    /// </summary>
    public class CompanyManage : IDomainService
    {
        private readonly IRepository<Company, int> _companyRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyManage(IRepository<Company, int> companyRepository)
        {
            _companyRepository = companyRepository;
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
