using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using PolyStone.Authorization.Users;

namespace PolyStone.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class UpdateUserDto: EntityDto<long>
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string NickName { get; set; }


//        [Required]
//        [StringLength(AbpUserBase.MaxSurnameLength)]
//        public string Surname { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; }
    }
}