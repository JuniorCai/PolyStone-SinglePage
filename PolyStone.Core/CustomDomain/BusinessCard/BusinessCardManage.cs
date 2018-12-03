using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PolyStone.CustomDomain.BusinessCard
{
    /// <summary>
    /// 名片业务管理
    /// </summary>
    public class BusinessCardManage : IDomainService
    {
        private readonly IRepository<BusinessCard, int> _businessCardRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public BusinessCardManage(IRepository<BusinessCard, int> businessCardRepository)
        {
            _businessCardRepository = businessCardRepository;
        }

        //TODO:编写领域业务代码


        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {


        }

        public async Task<IdentityResult> CreateAsync(BusinessCard card)
        {
            var result = new IdentityResult();
            try
            {
                _businessCardRepository.Insert(card);
            }
            catch (Exception e)
            {
                result = new IdentityResult("名片保存失败");
            }
            return result;

        }


    }
}
