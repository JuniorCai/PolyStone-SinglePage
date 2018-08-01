using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.Regions
{
    /// <summary>
    /// 地区表业务管理
    /// </summary>
    public class RegionManage : IDomainService
    {
        private readonly IRepository<Region,int> _regionRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public RegionManage(IRepository<Region,int> regionRepository  )
        {
            _regionRepository = regionRepository;
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
