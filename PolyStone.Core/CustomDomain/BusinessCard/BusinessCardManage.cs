using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
namespace PolyStone.CustomDomain.BusinessCard
{
    /// <summary>
    /// 名片业务管理
    /// </summary>
    public class BusinessCardManage : IDomainService
    {
        private readonly IRepository<BusinessCard,int> _businessCardRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public BusinessCardManage(IRepository<BusinessCard,int> businessCardRepository  )
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


		}

    
	
}
