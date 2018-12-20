using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.Authorization.Users;
using PolyStone.CommunityCategories.Dtos;
using PolyStone.CustomDomain.Communities;
using PolyStone.CustomDomain.CommunityCategories;
using PolyStone.Regions.Dtos;
using PolyStone.Users.Dto;


namespace PolyStone.Communities.Dtos
{
    /// <summary>
    /// 圈子信息表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Community))]
    public class CommunityListDto : EntityDto<int>
    {

        [DisplayName("标题")]
        public string Title { get; set; }

        [DisplayName("图片")]
        public string ImgUrls { get; set; }


        /// <summary>
        /// 个人会员ID
        /// </summary>
        [DisplayName("个人会员ID")]
        public int UserId { get; set; }

        public UserDto User { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [DisplayName("类别")]
        public int CommunityCategoryId { get; set; }


        public CommunityCategoryListDto CommunityCategory { get; set; }

        public string Detail { get; set; }

        public RegionListDto Region { get; set; }

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
