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
using PolyStone.CommunityCategories.Dtos;
using PolyStone.CustomDomain.CommunityCategories;
using PolyStone.CustomDomain.CommunityCategories.Authorization;

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
// Copyright © YoYoCms@China.2018-08-01T18:08:21. All Rights Reserved.
//<生成时间>2018-08-01T18:08:21</生成时间>
	#endregion


namespace PolyStone.CommunityCategories
{
    /// <summary>
    /// 圈子类别表服务实现
    /// </summary>
    [AbpAuthorize(CommunityCategoryAppPermissions.CommunityCategory)]


    public class CommunityCategoryAppService : PolyStoneAppServiceBase, ICommunityCategoryAppService
    {
        private readonly IRepository<CommunityCategory, int> _communityCategoryRepository;


        private readonly CommunityCategoryManage _communityCategoryManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CommunityCategoryAppService(IRepository<CommunityCategory, int> communityCategoryRepository,
            CommunityCategoryManage communityCategoryManage

        )
        {
            _communityCategoryRepository = communityCategoryRepository;
            _communityCategoryManage = communityCategoryManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<CommunityCategory> _communityCategoryRepositoryAsNoTrack =>
            _communityCategoryRepository.GetAll().AsNoTracking();


        #endregion


        #region 圈子类别表管理

        /// <summary>
        /// 根据查询条件获取圈子类别表分页列表
        /// </summary>
        public async Task<PagedResultDto<CommunityCategoryListDto>> GetPagedCommunityCategorysAsync(
            GetCommunityCategoryInput input)
        {

            var query = _communityCategoryRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var communityCategoryCount = await query.CountAsync();

            var communityCategorys = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var communityCategoryListDtos = communityCategorys.MapTo<List<CommunityCategoryListDto>>();
            return new PagedResultDto<CommunityCategoryListDto>(
                communityCategoryCount,
                communityCategoryListDtos
            );
        }

        /// <summary>
        /// 通过Id获取圈子类别表信息进行编辑或修改 
        /// </summary>
        public async Task<GetCommunityCategoryForEditOutput> GetCommunityCategoryForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCommunityCategoryForEditOutput();

            CommunityCategoryEditDto communityCategoryEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _communityCategoryRepository.GetAsync(input.Id.Value);
                communityCategoryEditDto = entity.MapTo<CommunityCategoryEditDto>();
            }
            else
            {
                communityCategoryEditDto = new CommunityCategoryEditDto();
            }

            output.CommunityCategory = communityCategoryEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取圈子类别表ListDto信息
        /// </summary>
        public async Task<CommunityCategoryListDto> GetCommunityCategoryByIdAsync(EntityDto<int> input)
        {
            var entity = await _communityCategoryRepository.GetAsync(input.Id);

            return entity.MapTo<CommunityCategoryListDto>();
        }







        /// <summary>
        /// 新增或更改圈子类别表
        /// </summary>
        public async Task CreateOrUpdateCommunityCategoryAsync(CreateOrUpdateCommunityCategoryInput input)
        {
            if (input.CommunityCategoryEditDto.Id.HasValue)
            {
                await UpdateCommunityCategoryAsync(input.CommunityCategoryEditDto);
            }
            else
            {
                await CreateCommunityCategoryAsync(input.CommunityCategoryEditDto);
            }
        }

        /// <summary>
        /// 新增圈子类别表
        /// </summary>
        [AbpAuthorize(CommunityCategoryAppPermissions.CommunityCategory_CreateCommunityCategory)]
        public virtual async Task<CommunityCategoryEditDto> CreateCommunityCategoryAsync(CommunityCategoryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<CommunityCategory>();

            entity = await _communityCategoryRepository.InsertAsync(entity);
            return entity.MapTo<CommunityCategoryEditDto>();
        }

        /// <summary>
        /// 编辑圈子类别表
        /// </summary>
        [AbpAuthorize(CommunityCategoryAppPermissions.CommunityCategory_EditCommunityCategory)]
        public virtual async Task UpdateCommunityCategoryAsync(CommunityCategoryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _communityCategoryRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _communityCategoryRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除圈子类别表
        /// </summary>
        [AbpAuthorize(CommunityCategoryAppPermissions.CommunityCategory_DeleteCommunityCategory)]
        public async Task DeleteCommunityCategoryAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _communityCategoryRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除圈子类别表
        /// </summary>
        [AbpAuthorize(CommunityCategoryAppPermissions.CommunityCategory_DeleteCommunityCategory)]
        public async Task BatchDeleteCommunityCategoryAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _communityCategoryRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


    }
}
