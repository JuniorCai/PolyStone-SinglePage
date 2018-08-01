using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CommunityCategories;


namespace PolyStone.CommunityCategories.Dtos
{
	/// <summary>
    /// 圈子类别表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(CommunityCategory))]
    public class CommunityCategoryListDto : EntityDto<int>
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        [DisplayName("类别名称")]
        public      string CategoryName { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        [DisplayName("父节点ID")]
        public      int ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public      int Sort { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [DisplayName("是否显示")]
        public      bool IsShow { get; set; }
        /// <summary>
        /// 是否生效
        /// </summary>
        [DisplayName("是否生效")]
        public      bool IsActive { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
