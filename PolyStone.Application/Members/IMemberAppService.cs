using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Members.Dtos;


namespace PolyStone.Members
{
	/// <summary>
    /// 个人会员信息表服务接口
    /// </summary>
    public interface IMemberAppService : IApplicationService
    {
        #region 个人会员信息表管理

        /// <summary>
        /// 根据查询条件获取个人会员信息表分页列表
        /// </summary>
        Task<PagedResultDto<MemberListDto>> GetPagedMembersAsync(GetMemberInput input);

        /// <summary>
        /// 通过Id获取个人会员信息表信息进行编辑或修改 
        /// </summary>
        Task<GetMemberForEditOutput> GetMemberForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取个人会员信息表ListDto信息
        /// </summary>
		Task<MemberListDto> GetMemberByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改个人会员信息表
        /// </summary>
        Task CreateOrUpdateMemberAsync(CreateOrUpdateMemberInput input);





        /// <summary>
        /// 新增个人会员信息表
        /// </summary>
        Task<MemberEditDto> CreateMemberAsync(MemberEditDto input);

        /// <summary>
        /// 更新个人会员信息表
        /// </summary>
        Task UpdateMemberAsync(MemberEditDto input);

        /// <summary>
        /// 删除个人会员信息表
        /// </summary>
        Task DeleteMemberAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除个人会员信息表
        /// </summary>
        Task BatchDeleteMemberAsync(List<int> input);

        #endregion




    }
}
