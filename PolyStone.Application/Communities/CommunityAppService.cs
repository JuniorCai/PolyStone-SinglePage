using System;
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
using PolyStone.CustomDomain.Products;

namespace PolyStone.Communities
{
    /// <summary>
    /// 圈子信息表服务实现
    /// </summary>

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
            DateTime now = DateTime.Now;
            DateTime? expire = null;
            if (input.RefreshExpire > 0)
            {
                expire = now.AddDays((-1) * input.RefreshExpire);
            }
            query = query.WhereIf(input.Id > 0, c => c.Id == input.Id)
                .WhereIf(!string.IsNullOrEmpty(input.Title), c => c.Detail.Contains(input.Title))
                .WhereIf(input.CommunityCategoryId > 0, c => c.CommunityCategoryId == input.CommunityCategoryId)
                .WhereIf(input.UserId > 0, c => c.UserId == input.UserId)
                .WhereIf(expire!=null, c=>c.RefreshDate<= expire)
                .WhereIf(input.VerifyStatus != VerifyStatus.Invalid, c => c.VerifyStatus == input.VerifyStatus)
                .WhereIf(input.ReleaseStatus != ReleaseStatus.Invalid, c => c.ReleaseStatus == input.ReleaseStatus)
                .WhereIf(input.FromTime != null, c => c.CreationTime >= input.FromTime)
                .WhereIf(input.EndTime != null, c => c.CreationTime <= input.EndTime);
            var communityCount = await query.CountAsync();

            switch (input.Sorting.ToLower())
            {
                case "refreshdate":
                    query = query.OrderByDescending(c => c.RefreshDate);
                    break;
                default:
                    query = query.OrderByDescending(c => c.CreationTime);
                    break;
            }
            var communitys = await query
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



        public async Task<List<CommunityListDto>> GetCommunityByUserIdAsync(EntityDto<int> input)
        {
            var communityList = await _communityRepository.GetAllListAsync(p => p.UserId == input.Id);
            return communityList.MapTo<List<CommunityListDto>>();
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

        [AbpAuthorize(CommunityAppPermissions.Community_EditCommunity)]
        public async Task OffLineCommunityAsync(EntityDto<int> input)
        {
            var entity = await _communityRepository.GetAsync(input.Id);
            entity.ReleaseStatus = ReleaseStatus.OffLine;

            await _communityRepository.UpdateAsync(entity);
        }

        [AbpAuthorize(CommunityAppPermissions.Community_EditCommunity)]
        public async Task OnLineCommunityAsync(EntityDto<int> input)
        {
            var entity = await _communityRepository.GetAsync(input.Id);
            entity.RefreshDate = DateTime.Now;
            entity.ReleaseStatus = ReleaseStatus.Publish;

            await _communityRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 新增圈子信息表
        /// </summary>
        [AbpAuthorize(CommunityAppPermissions.Community_CreateCommunity)]
        public virtual async Task<CommunityEditDto> CreateCommunityAsync(CommunityEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Community>();
            entity.VerifyStatus = VerifyStatus.Pass;
            entity.ReleaseStatus = ReleaseStatus.Publish;
            entity.RefreshDate = DateTime.Now;

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
            entity.RefreshDate = DateTime.Now;
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
