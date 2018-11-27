using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using PolyStone.Authorization.Users;

namespace PolyStone.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string NickName { get; set; }


//        [Required(AllowEmptyStrings = true)]
//        [StringLength(AbpUserBase.MaxSurnameLength)]
//        public string Surname { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public UserType UserType { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] Roles { get; set; }
    }
}
