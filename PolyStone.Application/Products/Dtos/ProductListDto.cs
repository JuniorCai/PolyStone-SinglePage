using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.Categories.Dtos;
using PolyStone.Companies.Dtos;
using PolyStone.CustomDomain.Products;


namespace PolyStone.Products.Dtos
{
    /// <summary>
    /// 产品表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Product))]
    public class ProductListDto : EntityDto<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 类目ID
        /// </summary>
        [DisplayName("类目ID")]
        public int CategoryId { get; set; }

        public CategoryListDto Category { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        [DisplayName("企业ID")]
        public int CompanyId { get; set; }

        public CompanyListDto Company { get; set; }

        public string CoverPhoto { get; set; }

        /// <summary>
        /// 产品图片URL
        /// </summary>
        [DisplayName("产品图片URL")]
        public string ImgUrls { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        [DisplayName("详情")]
        public string Detail { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        [DisplayName("审核状态")]
        public VerifyStatus VerifyStatus { get; set; }

        /// <summary>
        /// 审核状态(枚举描述)
        /// </summary>
        public string VerifyStatusName { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        [DisplayName("发布状态")]
        public ReleaseStatus ReleaseStatus { get; set; }

        /// <summary>
        /// 发布状态(枚举描述)
        /// </summary>
        public string ReleaseStatusName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
