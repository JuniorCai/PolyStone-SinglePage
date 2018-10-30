using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using PolyStone.CustomDomain.UserAuthorizations;
using PolyStone.CustomDomain.UserAuthorizations.Authorization;
using PolyStone.UserAuthorizations.Dtos;

namespace PolyStone.UserAuthorizations
{
    /// <summary>
    /// 用户第三方绑定服务实现
    /// </summary>
    [AbpAuthorize(UserAuthorizationAppPermissions.UserAuthorization)]


    public class UserAuthorizationAppService : PolyStoneAppServiceBase, IUserAuthorizationAppService
    {
        private readonly IRepository<UserAuthorization, int> _userAuthorizationRepository;


        private readonly UserAuthorizationManage _userAuthorizationManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserAuthorizationAppService(IRepository<UserAuthorization, int> userAuthorizationRepository,
            UserAuthorizationManage userAuthorizationManage

        )
        {
            _userAuthorizationRepository = userAuthorizationRepository;
            _userAuthorizationManage = userAuthorizationManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<UserAuthorization> _userAuthorizationRepositoryAsNoTrack =>
            _userAuthorizationRepository.GetAll().AsNoTracking();


        #endregion


        #region 用户第三方绑定管理

        /// <summary>
        /// 根据查询条件获取用户第三方绑定分页列表
        /// </summary>
        public async Task<PagedResultDto<UserAuthorizationListDto>> GetPagedUserAuthorizationsAsync(
            GetUserAuthorizationInput input)
        {

            var query = _userAuthorizationRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件
            query = query.WhereIf(string.IsNullOrEmpty(input.OpenId), u => u.OpenId == input.OpenId);
            query = query.WhereIf(input.UserId>0, u => u.UserId == input.UserId);


            var userAuthorizationCount = await query.CountAsync();

            var userAuthorizations = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var userAuthorizationListDtos = userAuthorizations.MapTo<List<UserAuthorizationListDto>>();
            return new PagedResultDto<UserAuthorizationListDto>(
                userAuthorizationCount,
                userAuthorizationListDtos
            );
        }

        /// <summary>
        /// 通过Id获取用户第三方绑定信息进行编辑或修改 
        /// </summary>
        public async Task<GetUserAuthorizationForEditOutput> GetUserAuthorizationForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetUserAuthorizationForEditOutput();

            UserAuthorizationEditDto userAuthorizationEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _userAuthorizationRepository.GetAsync(input.Id.Value);
                userAuthorizationEditDto = entity.MapTo<UserAuthorizationEditDto>();
            }
            else
            {
                userAuthorizationEditDto = new UserAuthorizationEditDto();
            }

            output.UserAuthorization = userAuthorizationEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取用户第三方绑定ListDto信息
        /// </summary>
        public async Task<UserAuthorizationListDto> GetUserAuthorizationByIdAsync(EntityDto<int> input)
        {
            var entity = await _userAuthorizationRepository.GetAsync(input.Id);

            return entity.MapTo<UserAuthorizationListDto>();
        }







        /// <summary>
        /// 新增或更改用户第三方绑定
        /// </summary>
        public async Task CreateOrUpdateUserAuthorizationAsync(CreateOrUpdateUserAuthorizationInput input)
        {
            if (input.UserAuthorizationEditDto.Id.HasValue)
            {
                await UpdateUserAuthorizationAsync(input.UserAuthorizationEditDto);
            }
            else
            {
                await CreateUserAuthorizationAsync(input.UserAuthorizationEditDto);
            }
        }

        /// <summary>
        /// 新增用户第三方绑定
        /// </summary>
        [AbpAuthorize(UserAuthorizationAppPermissions.UserAuthorization_CreateUserAuthorization)]
        public virtual async Task<UserAuthorizationEditDto> CreateUserAuthorizationAsync(UserAuthorizationEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<UserAuthorization>();

            entity = await _userAuthorizationRepository.InsertAsync(entity);
            return entity.MapTo<UserAuthorizationEditDto>();
        }

        /// <summary>
        /// 编辑用户第三方绑定
        /// </summary>
        [AbpAuthorize(UserAuthorizationAppPermissions.UserAuthorization_EditUserAuthorization)]
        public virtual async Task UpdateUserAuthorizationAsync(UserAuthorizationEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _userAuthorizationRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _userAuthorizationRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除用户第三方绑定
        /// </summary>
        [AbpAuthorize(UserAuthorizationAppPermissions.UserAuthorization_DeleteUserAuthorization)]
        public async Task DeleteUserAuthorizationAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _userAuthorizationRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除用户第三方绑定
        /// </summary>
        [AbpAuthorize(UserAuthorizationAppPermissions.UserAuthorization_DeleteUserAuthorization)]
        public async Task BatchDeleteUserAuthorizationAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _userAuthorizationRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
    }
}
