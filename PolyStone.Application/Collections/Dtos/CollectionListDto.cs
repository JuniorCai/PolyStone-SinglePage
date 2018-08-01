using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Collections;

namespace PolyStone.Collections.Dtos
{
    /// <summary>
    /// 用户收藏列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Collection))]
    public class CollectionListDto : EntityDto<int>
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public int RelativeId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
