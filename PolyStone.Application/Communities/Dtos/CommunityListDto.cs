using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Communities;



namespace PolyStone.Communities.Dtos
{
    /// <summary>
    /// 圈子信息表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Community))]
    public class CommunityListDto : EntityDto<int>
    {
        /// <summary>
        /// 个人会员ID
        /// </summary>
        [DisplayName("个人会员ID")]
        public int MemberId { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [DisplayName("类别")]
        public int Type { get; set; }

        /// <summary>
        /// 刷新时间
        /// </summary>
        [DisplayName("刷新时间")]
        public DateTime RefreshDate { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        [DisplayName("审核状态")]
        public int VerifyStatus { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        [DisplayName("发布状态")]
        public int ReleaseStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
