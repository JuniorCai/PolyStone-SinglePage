using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyIndustries;


namespace PolyStone.CompanyIndustries.Dtos
{
    /// <summary>
    /// 企业行业关系表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(CompanyIndustry))]
    public class CompanyIndustryListDto : EntityDto<int>
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        public int CompanyId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// 企业信息
        /// </summary>
        [DisplayName("企业信息")]
        public Company Company { get; set; }

        /// <summary>
        /// 行业ID
        /// </summary>
        [DisplayName("行业ID")]
        public int IndustryId { get; set; }

        /// <summary>
        /// 行业信息
        /// </summary>
        [DisplayName("行业信息")]
        public Industry Industry { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
