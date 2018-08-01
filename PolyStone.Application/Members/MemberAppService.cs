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
using PolyStone.CustomDomain.Members;
using PolyStone.CustomDomain.Members.Authorization;
using PolyStone.Members.Dtos;




namespace PolyStone.Members
{
    /// <summary>
    /// 个人会员信息表服务实现
    /// </summary>
    [AbpAuthorize(MemberAppPermissions.Member)]


    public class MemberAppService : PolyStoneAppServiceBase, IMemberAppService
    {
        private readonly IRepository<Member, int> _memberRepository;


        private readonly MemberManage _memberManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public MemberAppService(IRepository<Member, int> memberRepository,
            MemberManage memberManage

        )
        {
            _memberRepository = memberRepository;
            _memberManage = memberManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Member> _memberRepositoryAsNoTrack => _memberRepository.GetAll().AsNoTracking();


        #endregion


        #region 个人会员信息表管理

        /// <summary>
        /// 根据查询条件获取个人会员信息表分页列表
        /// </summary>
        public async Task<PagedResultDto<MemberListDto>> GetPagedMembersAsync(GetMemberInput input)
        {

            var query = _memberRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var memberCount = await query.CountAsync();

            var members = await query.OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            //var members = await query.OrderBy(input.Sorting).ToListAsync();

            var memberListDtos = members.MapTo<List<MemberListDto>>();
            return new PagedResultDto<MemberListDto>(
                memberCount,
                memberListDtos
            );
        }

        /// <summary>
        /// 通过Id获取个人会员信息表信息进行编辑或修改 
        /// </summary>
        public async Task<GetMemberForEditOutput> GetMemberForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetMemberForEditOutput();

            MemberEditDto memberEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _memberRepository.GetAsync(input.Id.Value);
                memberEditDto = entity.MapTo<MemberEditDto>();
            }
            else
            {
                memberEditDto = new MemberEditDto();
            }

            output.Member = memberEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取个人会员信息表ListDto信息
        /// </summary>
        public async Task<MemberListDto> GetMemberByIdAsync(EntityDto<int> input)
        {
            var entity = await _memberRepository.GetAsync(input.Id);

            return entity.MapTo<MemberListDto>();
        }







        /// <summary>
        /// 新增或更改个人会员信息表
        /// </summary>
        public async Task CreateOrUpdateMemberAsync(CreateOrUpdateMemberInput input)
        {
            if (input.MemberEditDto.Id.HasValue)
            {
                await UpdateMemberAsync(input.MemberEditDto);
            }
            else
            {
                await CreateMemberAsync(input.MemberEditDto);
            }
        }

        /// <summary>
        /// 新增个人会员信息表
        /// </summary>
        [AbpAuthorize(MemberAppPermissions.Member_CreateMember)]
        public virtual async Task<MemberEditDto> CreateMemberAsync(MemberEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Member>();

            entity = await _memberRepository.InsertAsync(entity);
            return entity.MapTo<MemberEditDto>();
        }

        /// <summary>
        /// 编辑个人会员信息表
        /// </summary>
        [AbpAuthorize(MemberAppPermissions.Member_EditMember)]
        public virtual async Task UpdateMemberAsync(MemberEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _memberRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _memberRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除个人会员信息表
        /// </summary>
        [AbpAuthorize(MemberAppPermissions.Member_DeleteMember)]
        public async Task DeleteMemberAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _memberRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除个人会员信息表
        /// </summary>
        [AbpAuthorize(MemberAppPermissions.Member_DeleteMember)]
        public async Task BatchDeleteMemberAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _memberRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        
    }
}
