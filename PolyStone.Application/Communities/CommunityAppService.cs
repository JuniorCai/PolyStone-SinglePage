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
using PolyStone.Communities.Dtos;
using PolyStone.CustomDomain.Communities;
using PolyStone.CustomDomain.Communities.Authorization;

#region 代码生成器相关信息_ABP Code Generator Info
   //你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
   //我的邮箱:werltm@hotmail.com
   // 官方网站:"http://www.yoyocms.com"
 // 交流QQ群：104390185  
 //微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2018-08-01T14:47:44. All Rights Reserved.
//<生成时间>2018-08-01T14:47:44</生成时间>
	#endregion


namespace PolyStone.Communities
{
    /// <summary>
    /// 圈子信息表服务实现
    /// </summary>
    [AbpAuthorize(CommunityAppPermissions.Community)]


    public class CommunityAppService : PolyStoneAppServiceBase, ICommunityAppService
    {
        private readonly IRepository<Community, int> _communityRepository;


        private readonly CommunityManage _communityManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CommunityAppService(IRepository<Community, int> communityRepository,
            CommunityManage communityManage

        )
        {
            _communityRepository = communityRepository;
            _communityManage = communityManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Community> _communityRepositoryAsNoTrack => _communityRepository.GetAll().AsNoTracking();


        #endregion


        #region 圈子信息表管理

        /// <summary>
        /// 根据查询条件获取圈子信息表分页列表
        /// </summary>
        public async Task<PagedResultDto<CommunityListDto>> GetPagedCommunitysAsync(GetCommunityInput input)
        {

            var query = _communityRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var communityCount = await query.CountAsync();

            var communitys = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var communityListDtos = communitys.MapTo<List<CommunityListDto>>();
            return new PagedResultDto<CommunityListDto>(
                communityCount,
                communityListDtos
            );
        }

        /// <summary>
        /// 通过Id获取圈子信息表信息进行编辑或修改 
        /// </summary>
        public async Task<GetCommunityForEditOutput> GetCommunityForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCommunityForEditOutput();

            CommunityEditDto communityEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _communityRepository.GetAsync(input.Id.Value);
                communityEditDto = entity.MapTo<CommunityEditDto>();
            }
            else
            {
                communityEditDto = new CommunityEditDto();
            }

            output.Community = communityEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取圈子信息表ListDto信息
        /// </summary>
        public async Task<CommunityListDto> GetCommunityByIdAsync(EntityDto<int> input)
        {
            var entity = await _communityRepository.GetAsync(input.Id);

            return entity.MapTo<CommunityListDto>();
        }







        /// <summary>
        /// 新增或更改圈子信息表
        /// </summary>
        public async Task CreateOrUpdateCommunityAsync(CreateOrUpdateCommunityInput input)
        {
            if (input.CommunityEditDto.Id.HasValue)
            {
                await UpdateCommunityAsync(input.CommunityEditDto);
            }
            else
            {
                await CreateCommunityAsync(input.CommunityEditDto);
            }
        }

        /// <summary>
        /// 新增圈子信息表
        /// </summary>
        [AbpAuthorize(CommunityAppPermissions.Community_CreateCommunity)]
        public virtual async Task<CommunityEditDto> CreateCommunityAsync(CommunityEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Community>();

            entity = await _communityRepository.InsertAsync(entity);
            return entity.MapTo<CommunityEditDto>();
        }

        /// <summary>
        /// 编辑圈子信息表
        /// </summary>
        [AbpAuthorize(CommunityAppPermissions.Community_EditCommunity)]
        public virtual async Task UpdateCommunityAsync(CommunityEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _communityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _communityRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除圈子信息表
        /// </summary>
        [AbpAuthorize(CommunityAppPermissions.Community_DeleteCommunity)]
        public async Task DeleteCommunityAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _communityRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除圈子信息表
        /// </summary>
        [AbpAuthorize(CommunityAppPermissions.Community_DeleteCommunity)]
        public async Task BatchDeleteCommunityAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _communityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


    }
}
