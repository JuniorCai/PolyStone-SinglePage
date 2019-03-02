using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;
using PolyStone.Authorization.Users;
using PolyStone.CompanyAuthes.Dtos;
using PolyStone.CompanyContacts.Dtos;
using PolyStone.CompanyIndustries.Dtos;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyContacts;
using PolyStone.CustomDomain.CompanyIndustries;
using PolyStone.CustomDomain.Products;
using PolyStone.Products.Dtos;
using PolyStone.Regions.Dtos;
using PolyStone.Users.Dto;


namespace PolyStone.Companies.Dtos
{
    /// <summary>
    /// 企业表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Company))]
    public class CompanyListDto : EntityDto<int>
    {
        /// <summary>
        /// 企业LOGO
        /// </summary>
        [DisplayName("企业LOGO")]
        public string Logo { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [DisplayName("企业名称")]
        public string CompanyName { get; set; }


        [DisplayName("企业简称")]
        public string ShortName { get; set; }


        /// <summary>
        /// 企业类型
        /// </summary>
        [DisplayName("企业类型")]
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// 企业类型(枚举描述)
        /// </summary>
        public string CompanyTypeName { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        [DisplayName("会员ID")]
        public int UserId { get; set; }

        public UserDto User { get; set; }

        public CompanyAuthListDto CompanyAuth { get; set; }

        public UserType UserType { get; set; }


        /// <summary>
        /// 是否已认证
        /// </summary>
        [DisplayName("是否已认证")]
        public bool IsAuthed { get; set; }

        /// <summary>
        /// 主营范围
        /// </summary>
        [DisplayName("主营范围")]
        public string Business { get; set; }

        /// <summary>
        /// 企业简介
        /// </summary>
        [DisplayName("企业简介")]
        public string Introduction { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        [DisplayName("地区Code")]
        public int RegionCode { get; set; }

        [DisplayName("地区")]
        public RegionListDto Region { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public bool IsActive { get; set; }


        /// <summary>
        /// 企业地址
        /// </summary>
        [DisplayName("企业地址")]
        public string Address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }

        public ICollection<ContactListDto> Contacts { get; set; }

        [JsonIgnore]
        protected ICollection<ProductListDto> Products { get; set; }

        public ICollection<CompanyIndustryListDto> Industries { get; set; }

    }
}
