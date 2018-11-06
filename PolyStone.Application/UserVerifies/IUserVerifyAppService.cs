using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.UserVerifies.Dtos;


namespace PolyStone.UserVerifies
{
    /// <summary>
    /// 用户验证码服务接口
    /// </summary>
    public interface IUserVerifyAppService : IApplicationService
    {
        #region 用户验证码管理

        /// <summary>
        /// 根据查询条件获取用户验证码分页列表
        /// </summary>
        Task<PagedResultDto<UserVerifyListDto>> GetPagedUserVerifysAsync(GetUserVerifyInput input);
        

        /// <summary>
        /// 通过Id获取用户验证码信息进行编辑或修改 
        /// </summary>
        Task<GetUserVerifyForEditOutput> GetUserVerifyForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取用户验证码ListDto信息
        /// </summary>
        Task<UserVerifyListDto> GetUserVerifyByIdAsync(EntityDto<int> input);

        Task<UserVerifyListDto> GetUserVerifyByPhoneNumberAsync(string phoneNumber);


        /// <summary>
        /// 新增或更改用户验证码
        /// </summary>
        Task CreateOrUpdateUserVerifyAsync(CreateOrUpdateUserVerifyInput input);





        /// <summary>
        /// 新增用户验证码
        /// </summary>
        Task<UserVerifyEditDto> CreateUserVerifyAsync(UserVerifyEditDto input);

        /// <summary>
        /// 更新用户验证码
        /// </summary>
        Task UpdateUserVerifyAsync(UserVerifyEditDto input);

        /// <summary>
        /// 删除用户验证码
        /// </summary>
        Task DeleteUserVerifyAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除用户验证码
        /// </summary>
        Task BatchDeleteUserVerifyAsync(List<int> input);

        #endregion
    }
}
