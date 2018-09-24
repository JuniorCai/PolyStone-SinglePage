using Abp.Domain.Repositories;
using Abp.Domain.Services;


namespace PolyStone.CustomDomain.CompanyIndustries.CompanyIndustries
{
    /// <summary>
    /// 企业行业关系表业务管理
    /// </summary>
    public class CompanyIndustryManage : IDomainService
    {
        private readonly IRepository<CompanyIndustry, int> _companyIndustryRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyIndustryManage(IRepository<CompanyIndustry, int> companyIndustryRepository)
        {
            _companyIndustryRepository = companyIndustryRepository;
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
