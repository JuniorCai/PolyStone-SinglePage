using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.UserAuthorizations;


namespace PolyStone.UserAuthorizations.Dtos
{
    /// <summary>
    /// 用户第三方绑定编辑用Dto
    /// </summary>
    [AutoMap(typeof(UserAuthorization))]
    public class UserAuthorizationEditDto 
    {

	/// <summary>
    ///   主键Id
    /// </summary>
    [DisplayName("主键Id")]
	public int? Id{get;set;}

        /// <summary>
        /// 第三方唯一标识
        /// </summary>
        [DisplayName("第三方唯一标识")]
        [Required]
        [MaxLength(100)]
        public   string  OpenId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [DisplayName("用户ID")]
        public   long  UserId { get; set; }

        /// <summary>
        /// 第三方名称
        /// </summary>
        [DisplayName("第三方名称")]
        [Required]
        [MaxLength(100)]
        public   string  ThirdName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        [Required]
        public   bool  IsActive { get; set; }

    }
}
