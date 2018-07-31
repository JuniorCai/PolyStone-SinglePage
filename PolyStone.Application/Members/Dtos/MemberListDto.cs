using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Members;


namespace PolyStone.Members.Dtos
{
	/// <summary>
    /// 个人会员信息表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Member))]
    public class MemberListDto : EntityDto<int>
    {
        /// <summary>
        /// 是否激活
        /// </summary>
        [DisplayName("是否激活")]
        public      bool IsActive { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
