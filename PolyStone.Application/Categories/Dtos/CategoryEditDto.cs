using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Categories;

namespace PolyStone.Categories.Dtos
{
    /// <summary>
    /// 产品类目编辑用Dto
    /// </summary>
    [AutoMap(typeof(Category))]
    public class CategoryEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 类目名称
        /// </summary>
        [DisplayName("类目名称")]
        [Required]
        [MaxLength(50)]
        public   string  CategoryName { get; set; }

        /// <summary>
        /// 类目简称
        /// </summary>
        [DisplayName("类目简称")]
        [Required]
        [MaxLength(50)]
        public   string  ShortName { get; set; }

        /// <summary>
        /// 父类目ID
        /// </summary>
        [DisplayName("父类目ID")]
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

        /// <summary>
        /// 是否生效
        /// </summary>
        [DisplayName("是否生效")]
        [Required]
        public   bool  IsActive { get; set; }

    }
}
