using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.UserAuthorizations;

namespace PolyStone.UserAuthorizations.Dtos
{
    /// <summary>
    /// 用户第三方绑定列表Dto
    /// </summary>
    [AutoMapFrom(typeof(UserAuthorization))]
    public class UserAuthorizationListDto : EntityDto<int>
    {
        /// <summary>
        /// 第三方唯一标识
        /// </summary>
        [DisplayName("第三方唯一标识")]
        public string OpenId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [DisplayName("用户ID")]
        public long UserId { get; set; }

        /// <summary>
        /// 第三方名称
        /// </summary>
        [DisplayName("第三方名称")]
        public string ThirdName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
