using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.Communities
{
    /// <summary>
    /// 圈子信息表业务管理
    /// </summary>
    public class CommunityManage : IDomainService
    {
        private readonly IRepository<Community, int> _communityRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CommunityManage(IRepository<Community, int> communityRepository)
        {
            _communityRepository = communityRepository;
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
