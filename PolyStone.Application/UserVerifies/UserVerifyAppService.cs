﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using PolyStone.CustomDomain.UserVerifies;
using PolyStone.CustomDomain.UserVerifies.Authorization;
using PolyStone.UserVerifies.Dtos;

namespace PolyStone.UserVerifies
{
    /// <summary>
    /// 用户验证码服务实现
    /// </summary>
    [AbpAuthorize(UserVerifyAppPermissions.UserVerify)]


    public class UserVerifyAppService : PolyStoneAppServiceBase, IUserVerifyAppService
    {
        private readonly IRepository<UserVerify, int> _userVerifyRepository;


        private readonly UserVerifyManage _userVerifyManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public UserVerifyAppService(IRepository<UserVerify, int> userVerifyRepository,
            UserVerifyManage userVerifyManage

        )
        {
            _userVerifyRepository = userVerifyRepository;
            _userVerifyManage = userVerifyManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<UserVerify> _userVerifyRepositoryAsNoTrack => _userVerifyRepository.GetAll().AsNoTracking();


        #endregion


        #region 用户验证码管理

        /// <summary>
        /// 根据查询条件获取用户验证码分页列表
        /// </summary>
        public async Task<PagedResultDto<UserVerifyListDto>> GetPagedUserVerifysAsync(GetUserVerifyInput input)
        {

            var query = _userVerifyRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var userVerifyCount = await query.CountAsync();

            var userVerifys = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var userVerifyListDtos = userVerifys.MapTo<List<UserVerifyListDto>>();
            return new PagedResultDto<UserVerifyListDto>(
                userVerifyCount,
                userVerifyListDtos
            );
        }

        /// <summary>
        /// 通过Id获取用户验证码信息进行编辑或修改 
        /// </summary>
        public async Task<GetUserVerifyForEditOutput> GetUserVerifyForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetUserVerifyForEditOutput();

            UserVerifyEditDto userVerifyEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _userVerifyRepository.GetAsync(input.Id.Value);
                userVerifyEditDto = entity.MapTo<UserVerifyEditDto>();
            }
            else
            {
                userVerifyEditDto = new UserVerifyEditDto();
            }

            output.UserVerify = userVerifyEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取用户验证码ListDto信息
        /// </summary>
        public async Task<UserVerifyListDto> GetUserVerifyByIdAsync(EntityDto<int> input)
        {
            var entity = await _userVerifyRepository.GetAsync(input.Id);

            return entity.MapTo<UserVerifyListDto>();
        }







        /// <summary>
        /// 新增或更改用户验证码
        /// </summary>
        public async Task CreateOrUpdateUserVerifyAsync(CreateOrUpdateUserVerifyInput input)
        {
            if (input.UserVerifyEditDto.Id.HasValue)
            {
                await UpdateUserVerifyAsync(input.UserVerifyEditDto);
            }
            else
            {
                await CreateUserVerifyAsync(input.UserVerifyEditDto);
            }
        }

        /// <summary>
        /// 新增用户验证码
        /// </summary>
        [AbpAuthorize(UserVerifyAppPermissions.UserVerify_CreateUserVerify)]
        public virtual async Task<UserVerifyEditDto> CreateUserVerifyAsync(UserVerifyEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<UserVerify>();

            entity = await _userVerifyRepository.InsertAsync(entity);
            return entity.MapTo<UserVerifyEditDto>();
        }

        /// <summary>
        /// 编辑用户验证码
        /// </summary>
        [AbpAuthorize(UserVerifyAppPermissions.UserVerify_EditUserVerify)]
        public virtual async Task UpdateUserVerifyAsync(UserVerifyEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _userVerifyRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _userVerifyRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除用户验证码
        /// </summary>
        [AbpAuthorize(UserVerifyAppPermissions.UserVerify_DeleteUserVerify)]
        public async Task DeleteUserVerifyAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _userVerifyRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除用户验证码
        /// </summary>
        [AbpAuthorize(UserVerifyAppPermissions.UserVerify_DeleteUserVerify)]
        public async Task BatchDeleteUserVerifyAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _userVerifyRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
    }
}