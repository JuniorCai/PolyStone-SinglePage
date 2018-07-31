using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.Members
{
    /// <summary>
    /// 个人会员信息表业务管理
    /// </summary>
    public class MemberManage : IDomainService
    {
        private readonly IRepository<Member, int> _memberRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public MemberManage(IRepository<Member, int> memberRepository)
        {
            _memberRepository = memberRepository;
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
