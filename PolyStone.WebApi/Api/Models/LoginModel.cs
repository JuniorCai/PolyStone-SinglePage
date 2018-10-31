using System.ComponentModel.DataAnnotations;
using Abp.Authorization;

namespace PolyStone.Api.Models
{
    public class LoginModel
    {
        public string TenancyName { get; set; }

        public string UsernameOrEmailAddress { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        public LoginType LoginType { get; set; }
    }

    /// <summary>
    /// 登录方式
    /// </summary>
    public enum LoginType
    {
        Account=1,
        PhoneCode=2,
        Wx=3
    }
}