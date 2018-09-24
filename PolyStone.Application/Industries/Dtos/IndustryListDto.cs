using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CompanyIndustries;

namespace PolyStone.Industries.Dtos
{
	/// <summary>
    /// 企业行业表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Industry))]
    public class IndustryListDto : EntityDto<int>
    {
        /// <summary>
        /// 行业名称
        /// </summary>
        [DisplayName("行业名称")]
        public      string IndustryName { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("编号")]
        public      string IndustryCode { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        [DisplayName("父级编号")]
        public      int ParentCode { get; set; }
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
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public      bool IsActive { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
