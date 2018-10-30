using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.UserAuthorizations.Dtos;

namespace PolyStone.UserAuthorizations
{
    /// <summary>
    /// 用户第三方绑定服务接口
    /// </summary>
    public interface IUserAuthorizationAppService : IApplicationService
    {
        #region 用户第三方绑定管理

        /// <summary>
        /// 根据查询条件获取用户第三方绑定分页列表
        /// </summary>
        Task<PagedResultDto<UserAuthorizationListDto>> GetPagedUserAuthorizationsAsync(GetUserAuthorizationInput input);

        /// <summary>
        /// 通过Id获取用户第三方绑定信息进行编辑或修改 
        /// </summary>
        Task<GetUserAuthorizationForEditOutput> GetUserAuthorizationForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取用户第三方绑定ListDto信息
        /// </summary>
        Task<UserAuthorizationListDto> GetUserAuthorizationByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改用户第三方绑定
        /// </summary>
        Task CreateOrUpdateUserAuthorizationAsync(CreateOrUpdateUserAuthorizationInput input);





        /// <summary>
        /// 新增用户第三方绑定
        /// </summary>
        Task<UserAuthorizationEditDto> CreateUserAuthorizationAsync(UserAuthorizationEditDto input);

        /// <summary>
        /// 更新用户第三方绑定
        /// </summary>
        Task UpdateUserAuthorizationAsync(UserAuthorizationEditDto input);

        /// <summary>
        /// 删除用户第三方绑定
        /// </summary>
        Task DeleteUserAuthorizationAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除用户第三方绑定
        /// </summary>
        Task BatchDeleteUserAuthorizationAsync(List<int> input);

        #endregion




    }
}
