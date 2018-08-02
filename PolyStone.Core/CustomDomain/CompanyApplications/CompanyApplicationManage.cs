                          
 
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.CompanyApplications
{
    /// <summary>
    /// 个人会员升级企业申请表业务管理
    /// </summary>
    public class CompanyApplicationManage : IDomainService
    {
        private readonly IRepository<CompanyApplication, int> _companyApplicationRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyApplicationManage(IRepository<CompanyApplication, int> companyApplicationRepository)
        {
            _companyApplicationRepository = companyApplicationRepository;
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
