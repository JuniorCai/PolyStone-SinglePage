﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Companies;

namespace PolyStone.Companies.Dtos
{
    /// <summary>
    /// 企业表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Company))]
    public class CompanyEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 企业LOGO
        /// </summary>
        [DisplayName("企业LOGO")]
        [MaxLength(100)]
        public string Logo { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [DisplayName("企业名称")]
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }


        /// <summary>
        /// 企业简称
        /// </summary>
        [DisplayName("企业简称")]
        [Required]
        [MaxLength(50)]
        public string ShortName { get; set; }


        /// <summary>
        /// 企业类型
        /// </summary>
        [DisplayName("企业类型")]
        [Required]
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        [DisplayName("会员ID")]
        [Required]
        [Range(1, 11)]
        public int UserId { get; set; }

        /// <summary>
        /// 是否已认证
        /// </summary>
        [DisplayName("是否已认证")]
        [Required]
        public bool IsAuthed { get; set; }

        /// <summary>
        /// 主营范围
        /// </summary>
        [DisplayName("主营范围")]
        [Required]
        [MaxLength(200)]
        public string Business { get; set; }

        /// <summary>
        /// 企业简介
        /// </summary>
        [DisplayName("企业简介")]
        [MaxLength(2000)]
        public string Introduction { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        [DisplayName("地区ID")]
        [Required]
        public int RegionCode { get; set; }


        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        [Required]
        public bool IsActive { get; set; }


        /// <summary>
        /// 企业地址
        /// </summary>
        [DisplayName("企业地址")]
        [MaxLength(100)]
        public string Address { get; set; }

        [DisplayName("企业行业类别集合")]
        [Required]
        public string Industry { get; set; }

        public int ViewTimes { get; set; }

        public string Banners { get; set; }

    }
}
