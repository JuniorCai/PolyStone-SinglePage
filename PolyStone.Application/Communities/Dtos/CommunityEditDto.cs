﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Communities;
using PolyStone.CustomDomain.Products;


namespace PolyStone.Communities.Dtos
{
    /// <summary>
    /// 圈子信息表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Community))]
    public class CommunityEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 个人会员ID
        /// </summary>
        [DisplayName("个人会员ID")]
        [Required]
        [Range(1, 11)]
        public int MemberId { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [DisplayName("类别")]
        [Required]
        [Range(1, 11)]
        public int Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// 图片URL集合
        /// </summary>
        [DisplayName("图片URL集合")]
        [Required]
        [MaxLength(1000)]
        public string PictureUrls { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        [Required]
        [MaxLength(1000)]
        public string Detail { get; set; }

        /// <summary>
        /// 刷新时间
        /// </summary>
        [DisplayName("刷新时间")]
        [Required] public DateTime RefreshDate { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        [DisplayName("审核状态")]
        [Required]
        public VerifyStatus VerifyStatus { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        [DisplayName("发布状态")]
        [Required]
        public ReleaseStatus ReleaseStatus { get; set; }

    }
}