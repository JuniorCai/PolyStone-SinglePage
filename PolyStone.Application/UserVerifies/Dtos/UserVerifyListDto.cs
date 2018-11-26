using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.UserVerifies;



namespace PolyStone.UserVerifies.Dtos
{
    /// <summary>
    /// 用户验证码列表Dto
    /// </summary>
    [AutoMapFrom(typeof(UserVerify))]
    public class UserVerifyListDto : EntityDto<int>
    {
        /// <summary>
        /// 验证码类型
        /// </summary>
        [DisplayName("验证码类型")]
        public CodeType CodeType { get; set; }

        [DisplayName("验证码用途")]
        public PurposeType Purpose { get; set; }


        /// <summary>
        /// 失效时间
        /// </summary>
        [DisplayName("失效时间")]
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// 验证状态
        /// </summary>
        [DisplayName("验证状态")]
        public CodeVerifyStatus VerifyStatus { get; set; }

        /// <summary>
        /// 验证状态(枚举描述)
        /// </summary>
        public string VerifyStatusName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
