using System;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;

namespace PolyStone.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };

            return user;
        }

        public override string FullName => Surname + " " + Name;

        [Required(AllowEmptyStrings = true)]
        public override string EmailAddress { get; set; }

        [Required]
        [StringLength(32)]
        public string NickName { get; set; }

        public UserType UserType { get; set; }
    }

    /// <summary>
    /// 用户类型枚举
    /// </summary>
    public enum UserType
    {
        Admin = 0,
        Person = 1,
        Company = 2
    }
}