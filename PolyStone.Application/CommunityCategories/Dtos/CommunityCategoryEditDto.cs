using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.CommunityCategories;


namespace PolyStone.CommunityCategories.Dtos
{
    /// <summary>
    /// 圈子类别表编辑用Dto
    /// </summary>
    [AutoMap(typeof(CommunityCategory))]
    public class CommunityCategoryEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 类别名称
        /// </summary>
        [DisplayName("类别名称")]
        [Required]
        [MaxLength(50)]
        public   string  CategoryName { get; set; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        [DisplayName("父节点ID")]
        [Required]
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
