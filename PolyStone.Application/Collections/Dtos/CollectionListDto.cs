using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.Communities.Dtos;
using PolyStone.Companies.Dtos;
using PolyStone.CustomDomain.Collections;
using PolyStone.Modules.Dtos;
using PolyStone.Products.Dtos;

namespace PolyStone.Collections.Dtos
{
    /// <summary>
    /// 用户收藏列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Collection))]
    public class CollectionListDto : EntityDto<int>
    {
        public int ModuleId { get; set; }
        public ModuleListDto Module { get; set; }

        public long UserId { get; set; }
        public string Name { get; set; }
        public int RelativeId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }

        public ProductListDto Product { get; set; }

        public CompanyListDto Company { get; set; }
        public CommunityListDto Community { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
