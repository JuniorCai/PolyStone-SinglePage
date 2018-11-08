using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Users;

namespace PolyStone.Api.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// 是否为外部第三方登录
        /// </summary>
        public bool IsExternalLogin { get; set; }

    }
}

