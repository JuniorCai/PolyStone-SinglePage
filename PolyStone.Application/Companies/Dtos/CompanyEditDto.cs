using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Companies;

namespace PolyStone.Companies.Dtos
{
    /// <summary>
    /// 企业表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Company))]
    public class CompanyEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        [Required] public string CompanyName { get; set; }

        [Required] [Range(1, 11)] public int MemberId { get; set; }

        [Required] public bool IsAuthed { get; set; }

        [Required] [MaxLength(500)] public string Bussiness { get; set; }

        [Required] [MaxLength(2000)] public string Introduction { get; set; }

        [Required] [Range(1, 11)] public int RegionId { get; set; }

    }
}
