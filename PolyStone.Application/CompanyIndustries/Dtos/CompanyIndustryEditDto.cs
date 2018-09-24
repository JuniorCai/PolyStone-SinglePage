using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CompanyIndustries;

namespace PolyStone.CompanyIndustries.Dtos
{
    /// <summary>
    /// 企业行业关系表编辑用Dto
    /// </summary>
    [AutoMap(typeof(CompanyIndustry))]
    public class CompanyIndustryEditDto 
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
        public   int  CompanyId { get; set; }

        /// <summary>
        /// 行业ID
        /// </summary>
        [DisplayName("行业ID")]
        [Required]
        public   int  IndustryId { get; set; }

    }
}
