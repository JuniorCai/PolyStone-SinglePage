using Abp.Domain.Repositories;
using Abp.Domain.Services;


namespace PolyStone.CustomDomain.UserAuthorizations
{
    /// <summary>
    /// 用户第三方绑定业务管理
    /// </summary>
    public class UserAuthorizationManage : IDomainService
    {
        private readonly IRepository<UserAuthorization, int> _userAuthorizationRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserAuthorizationManage(IRepository<UserAuthorization, int> userAuthorizationRepository)
        {
            _userAuthorizationRepository = userAuthorizationRepository;
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
