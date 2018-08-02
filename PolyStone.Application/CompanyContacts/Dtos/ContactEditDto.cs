﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CompanyContacts;

namespace PolyStone.CompanyContacts.Dtos
{
    /// <summary>
    /// 企业联系表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Contact))]
    public class ContactEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        [Required]
        [Range(1, 11)]
        public   int  CompanyId { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DisplayName("联系人姓名")]
        [Required]
        [MaxLength(20)]
        public   string  LinkMan { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayName("手机号码")]
        [Required]
        [MaxLength(20)]
        public   string  Phone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        [Required]
        [MaxLength(20)]
        public   string  Tel { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [DisplayName("传真")]
        [Required]
        [MaxLength(20)]
        public   string  Fax { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [DisplayName("邮编")]
        [Required]
        [MaxLength(50)]
        public   string  Email { get; set; }

        /// <summary>
        /// 是否默认联系方式
        /// </summary>
        [DisplayName("是否默认联系方式")]
        [Required]
        public   bool  IsDefault { get; set; }

    }
}