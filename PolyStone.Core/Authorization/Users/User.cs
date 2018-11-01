using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Extensions;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PolyStone.CustomDomain.Communities;
using PolyStone.CustomDomain.Companies;

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

        [JsonIgnore]
        public virtual ICollection<Community> Communities { get; set; }

        /// <summary>
        /// Login definitions for this user.
        /// </summary>
        [JsonIgnore]
        [ForeignKey("UserId")]
        public override ICollection<UserLogin> Logins { get; set; }

        /// <summary>
        /// Roles of this user.
        /// </summary>
        [ForeignKey("UserId")]
        [JsonIgnore]
        public override ICollection<UserRole> Roles { get; set; }

        /// <summary>
        /// Claims of this user.
        /// </summary>
        [ForeignKey("UserId")]
        [JsonIgnore]
        public  override ICollection<UserClaim> Claims { get; set; }

        /// <summary>
        /// Permission definitions for this user.
        /// </summary>
        [ForeignKey("UserId")]
        [JsonIgnore]
        public override ICollection<UserPermissionSetting> Permissions { get; set; }

        /// <summary>
        /// Settings for this user.
        /// </summary>
        [ForeignKey("UserId")]
        [JsonIgnore]
        public override ICollection<Setting> Settings { get; set; }

        [JsonIgnore]
        public override User DeleterUser { get; set; }
        [JsonIgnore]
        public override User CreatorUser { get; set; }
        [JsonIgnore]
        public override User LastModifierUser { get; set; }

        public override string FullName => Surname + " " + Name;

        [Required(AllowEmptyStrings = true)]
        public override string EmailAddress { get; set; }

        [StringLength(32)]
        public string NickName { get; set; }

        public UserType UserType { get; set; }

        public string Avatar { get; set; }
        //public virtual Company Company { get; set; }
    }

    /// <summary>
    /// 用户类型枚举
    /// </summary>
    public enum UserType
    {
        Admin = 0,
        Person = 1,
        Company = 2,
        VipCompany = 3
    }
}