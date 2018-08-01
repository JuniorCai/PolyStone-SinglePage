                          
 
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.CommunityCategories
{
    /// <summary>
    /// 圈子类别表业务管理
    /// </summary>
    public class CommunityCategoryManage : IDomainService
    {
        private readonly IRepository<CommunityCategory,int> _communityCategoryRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public CommunityCategoryManage(IRepository<CommunityCategory,int> communityCategoryRepository  )
        {
            _communityCategoryRepository = communityCategoryRepository;
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
