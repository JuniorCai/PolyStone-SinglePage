using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Products;


namespace PolyStone.Products.Dtos
{
    /// <summary>
    /// 产品表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 类目ID
        /// </summary>
        [DisplayName("类目ID")]
        [Required]
        [Range(1, 11)]
        public int CategoryId { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        [Required]
        [Range(1, 11)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 产品图片URL
        /// </summary>
        [DisplayName("产品封面图片URL")]
        [Required]
        [MaxLength(1000)]
        public string CoverPhoto { get; set; }


        /// <summary>
        /// 产品图片URL
        /// </summary>
        [DisplayName("产品图片URL")]
        [Required]
        [MaxLength(1000)]
        public string ImgUrls { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        [DisplayName("详情")]
        [Required]
        [MaxLength(1000)]
        public string Detail { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        [DisplayName("审核状态")]
        [Required] public VerifyStatus VerifyStatus { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        [DisplayName("发布状态")]
        [Required] public ReleaseStatus ReleaseStatus { get; set; }

    }
}
