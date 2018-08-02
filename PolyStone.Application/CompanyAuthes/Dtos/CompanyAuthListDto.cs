using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CompanyAuths;


namespace PolyStone.CompanyAuthes.Dtos
{
	/// <summary>
    /// 企业资质表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(CompanyAuth))]
    public class CompanyAuthListDto : EntityDto<int>
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        public      int CompanyId { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        [DisplayName("法人姓名")]
        public      string LegalPerson { get; set; }
        /// <summary>
        /// 法人身份证正面
        /// </summary>
        [DisplayName("法人身份证正面")]
        public      string FrontImg { get; set; }
        /// <summary>
        /// 法人身份证反面
        /// </summary>
        [DisplayName("法人身份证反面")]
        public      string BackImg { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        [DisplayName("营业执照")]
        public      string License { get; set; }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        [DisplayName("最后编辑时间")]
        public      DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
