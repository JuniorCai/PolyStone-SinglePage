using System.ComponentModel;
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
        ///   Id
        /// </summary>
        [DisplayName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 企业ID-主键ID
        /// </summary>
        [DisplayName("企业ID")]
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DisplayName("联系人姓名")]
        [Required]
        [MaxLength(20)]
        public string LinkMan { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayName("手机号码")]
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        [MaxLength(20)]
        public string Tel { get; set; }


        /// <summary>
        /// 邮件
        /// </summary>
        [DisplayName("邮件")]
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 是否默认联系方式
        /// </summary>
        [DisplayName("是否默认联系方式")]
        [Required]
        public bool IsDefault { get; set; }

    }
}
