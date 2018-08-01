﻿using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Regions;


namespace PolyStone.Regions.Dtos
{
	/// <summary>
    /// 地区表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Region))]
    public class RegionListDto : EntityDto<int>
    {
        /// <summary>
        /// 地区名称
        /// </summary>
        [DisplayName("地区名称")]
        public      string RegionName { get; set; }
        /// <summary>
        /// 父类ID
        /// </summary>
        [DisplayName("父类ID")]
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
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}