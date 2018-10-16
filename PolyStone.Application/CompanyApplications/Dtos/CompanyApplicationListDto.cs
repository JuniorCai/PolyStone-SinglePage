using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyApplications;
using PolyStone.Regions.Dtos;
using PolyStone.Users.Dto;


namespace PolyStone.CompanyApplications.Dtos
{
    /// <summary>
    /// 个人会员升级企业申请表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(CompanyApplication))]
    public class CompanyApplicationListDto : EntityDto<int>
    {

        public int UserId { get; set; }

        public UserDto User { get; set; }

        /// <summary>
        /// 公司类型
        /// </summary>
        [DisplayName("公司类型")]
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// 公司类型(枚举描述)
        /// </summary>
        public string CompanyTypeName { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [DisplayName("营业执照")]
        public string License { get; set; }

        /// <summary>
        /// 法人姓名
        /// </summary>
        [DisplayName("法人姓名")]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 身份证正面照
        /// </summary>
        [DisplayName("身份证正面照")]
        public string FrontImg { get; set; }

        /// <summary>
        /// 身份证背面照
        /// </summary>
        [DisplayName("身份证背面照")]
        public string BackImg { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [DisplayName("企业名称")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 主营范围
        /// </summary>
        [DisplayName("主营范围")]
        public string Business { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        [DisplayName("地区ID")]
        public int RegionId { get; set; }

        public RegionListDto Region { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DisplayName("联系人姓名")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DisplayName("手机号")]
        public string Phone { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [DisplayName("电话号码")]
        public string Tel { get; set; }

        /// <summary>
        /// 企业地址
        /// </summary>
        [DisplayName("企业地址")]
        public string Address { get; set; }

        /// <summary>
        /// 认证状态
        /// </summary>
        [DisplayName("认证状态")]
        public AuthStatus AuthStatus { get; set; }

        /// <summary>
        /// 认证状态(枚举描述)
        /// </summary>
        public string AuthStautsName { get; set; }

        /// <summary>
        /// 最后编辑时间
        /// </summary>
        [DisplayName("最后编辑时间")]
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
