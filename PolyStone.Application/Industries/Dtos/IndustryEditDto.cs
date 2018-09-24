using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CompanyIndustries;

namespace PolyStone.Industries.Dtos
{
    /// <summary>
    /// 企业行业表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Industry))]
    public class IndustryEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 行业名称
        /// </summary>
        [DisplayName("行业名称")]
        [Required]
        [MaxLength(50)]
        public   string  IndustryName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("编号")]
        [Required]
        [MaxLength(10)]
        public   string  IndustryCode { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        [DisplayName("父级编号")]
        public   int  ParentCode { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        [Required]
        public   int  Sort { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [DisplayName("是否显示")]
        [Required]
        public   bool  IsShow { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        [Required]
        public   bool  IsActive { get; set; }

    }
}
