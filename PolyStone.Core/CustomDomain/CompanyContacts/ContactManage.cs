using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace PolyStone.CustomDomain.CompanyContacts
{
    /// <summary>
    /// 企业联系表业务管理
    /// </summary>
    public class ContactManage : IDomainService
    {
        private readonly IRepository<Contact, int> _contactRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ContactManage(IRepository<Contact, int> contactRepository)
        {
            _contactRepository = contactRepository;
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
