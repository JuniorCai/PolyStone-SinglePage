using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Regions;


namespace PolyStone.Regions.Dtos
{
    /// <summary>
    /// 地区表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Region))]
    public class RegionEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 地区名称
        /// </summary>
        [DisplayName("地区名称")]
        [Required]
        [MaxLength(50)]
        public   string  RegionName { get; set; }

        /// <summary>
        /// 父类ID
        /// </summary>
        [DisplayName("父类ID")]
        [Required]
        [Range(1, 11)]
        public   int  ParentId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        [Required]
        [Range(1, 11)]
        public   int  Sort { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [DisplayName("是否显示")]
        [Required]
        public   bool  IsShow { get; set; }

    }
}
