using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Members;


namespace PolyStone.Members.Dtos
{
    /// <summary>
    /// 个人会员信息表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Member))]
    public class MemberEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        [Required]
        [MaxLength(50)]
        public   string  AccountName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [MaxLength(50)]
        public   string  FullName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [DisplayName("昵称")]
        [Required]
        [MaxLength(50)]
        public   string  NickName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DisplayName("手机号")]
        [Required]
        [MaxLength(50)]
        public   string  Phone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [Required]
        [MaxLength(50)]
        public   string  Password { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        [DisplayName("是否激活")]
        [Required]
        public   bool  IsActive { get; set; }

    }
}
