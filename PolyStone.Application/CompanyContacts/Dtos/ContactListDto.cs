using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CompanyContacts;

namespace PolyStone.CompanyContacts.Dtos
{
	/// <summary>
    /// 企业联系表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Contact))]
    public class ContactListDto : EntityDto<int>
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        public      int CompanyId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DisplayName("联系人姓名")]
        public      string LinkMan { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayName("手机号码")]
        public      string Phone { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        public      string Tel { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [DisplayName("传真")]
        public      string Fax { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [DisplayName("邮编")]
        public      string Email { get; set; }
        /// <summary>
        /// 是否默认联系方式
        /// </summary>
        [DisplayName("是否默认联系方式")]
        public      bool IsDefault { get; set; }
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
