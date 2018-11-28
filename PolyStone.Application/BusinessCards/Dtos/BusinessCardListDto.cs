using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.BusinessCard;


namespace PolyStone.BusinessCards.Dtos
{
    /// <summary>
    /// 名片列表Dto
    /// </summary>
    [AutoMapFrom(typeof(BusinessCard))]
    public class BusinessCardListDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public string WxNumber { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Introduction { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}