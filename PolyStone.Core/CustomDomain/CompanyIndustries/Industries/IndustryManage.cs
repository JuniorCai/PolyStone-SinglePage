using Abp.Domain.Repositories;
using Abp.Domain.Services;


namespace PolyStone.CustomDomain.CompanyIndustries.Industries
{
    /// <summary>
    /// 企业行业表业务管理
    /// </summary>
    public class IndustryManage : IDomainService
    {
        private readonly IRepository<Industry, int> _industryRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public IndustryManage(IRepository<Industry, int> industryRepository)
        {
            _industryRepository = industryRepository;
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
