                          
 
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
namespace PolyStone.CustomDomain.UserVerifies
{
    /// <summary>
    /// 用户验证码业务管理
    /// </summary>
    public class UserVerifyManage : IDomainService
    {
        private readonly IRepository<UserVerify,int> _userVerifyRepository;

         /// <summary>
        /// 构造方法
        /// </summary>
        public UserVerifyManage(IRepository<UserVerify,int> userVerifyRepository  )
        {
            _userVerifyRepository = userVerifyRepository;
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
