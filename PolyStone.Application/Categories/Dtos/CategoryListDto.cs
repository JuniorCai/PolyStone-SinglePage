using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Categories;


namespace PolyStone.Categories.Dtos
{
	/// <summary>
    /// 产品类目列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Category))]
    public class CategoryListDto : EntityDto<int>
    {
        /// <summary>
        /// 父类目ID
        /// </summary>
        [DisplayName("父类目ID")]
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
