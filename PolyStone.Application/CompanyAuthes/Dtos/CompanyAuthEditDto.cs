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
        [Range(1, 11)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 法人姓名
        /// </summary>
        [DisplayName("法人姓名")]
        [Required]
        [MaxLength(50)]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 法人身份证正面
        /// </summary>
        [DisplayName("法人身份证正面")]
        [Required]
        [MaxLength(50)]
        public string FrontImg { get; set; }

        /// <summary>
        /// 法人身份证反面
        /// </summary>
        [DisplayName("法人身份证反面")]
        [Required]
        [MaxLength(50)]
        public string BackImg { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [DisplayName("营业执照")]
        [Required]
        [MaxLength(50)]
        public string License { get; set; }

    }
}
