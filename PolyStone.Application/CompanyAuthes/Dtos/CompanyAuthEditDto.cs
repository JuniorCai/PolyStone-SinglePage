using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CompanyAuths;

namespace PolyStone.CompanyAuthes.Dtos
{
    /// <summary>
    /// 企业资质表编辑用Dto
    /// </summary>
    [AutoMap(typeof(CompanyAuth))]
    public class CompanyAuthEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// 法人姓名
        /// </summary>
        [DisplayName("法人姓名")]
        [MaxLength(50)]
        [Required]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 法人身份证正面
        /// </summary>
        [DisplayName("法人身份证正面")]
        [MaxLength(100)]
        [Required]
        public string FrontImg { get; set; }

        /// <summary>
        /// 法人身份证反面
        /// </summary>
        [DisplayName("法人身份证反面")]
        [MaxLength(100)]
        [Required]
        public string BackImg { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [DisplayName("营业执照")]
        [MaxLength(100)]
        [Required]
        public string License { get; set; }

    }
}
