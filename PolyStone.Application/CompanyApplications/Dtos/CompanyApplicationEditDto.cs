using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyApplications;


namespace PolyStone.CompanyApplications.Dtos
{
    /// <summary>
    /// 个人会员升级企业申请表编辑用Dto
    /// </summary>
    [AutoMap(typeof(CompanyApplication))]
    public class CompanyApplicationEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 公司类型
        /// </summary>
        [DisplayName("公司类型")]
        [Required] public CompanyType CompanyType { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [DisplayName("营业执照")]
        [Required]
        [MaxLength(50)]
        public string License { get; set; }

        /// <summary>
        /// 法人姓名
        /// </summary>
        [DisplayName("法人姓名")]
        [Required]
        [MaxLength(50)]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 身份证正面照
        /// </summary>
        [DisplayName("身份证正面照")]
        [Required]
        [MaxLength(50)]
        public string FrontImg { get; set; }

        /// <summary>
        /// 身份证背面照
        /// </summary>
        [DisplayName("身份证背面照")]
        [Required]
        [MaxLength(50)]
        public string BackImg { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [DisplayName("企业名称")]
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 主营范围
        /// </summary>
        [DisplayName("主营范围")]
        [Required]
        [MaxLength(200)]
        public string Business { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        [DisplayName("地区ID")]
        [Required]
        [Range(1, 11)]
        public int RegionId { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [DisplayName("联系人姓名")]
        [Required]
        [MaxLength(20)]
        public string LinkMan { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DisplayName("手机号")]
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [DisplayName("电话号码")]
        [Required]
        [MaxLength(20)]
        public string Tel { get; set; }

        /// <summary>
        /// 企业地址
        /// </summary>
        [DisplayName("企业地址")]
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        /// <summary>
        /// 认证状态
        /// </summary>
        [DisplayName("认证状态")]
        [Required] public AuthStatus AuthStatus { get; set; }

    }
}