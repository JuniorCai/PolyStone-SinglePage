using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.BusinessCard;

namespace PolyStone.BusinessCards.Dtos
{
    /// <summary>
    /// 名片编辑用Dto
    /// </summary>
    [AutoMap(typeof(BusinessCard))]
    public class BusinessCardEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        public string WxNumber { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        public string Position { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(1000)]
        public string Introduction { get; set; }

    }
}