using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Collections;


namespace PolyStone.Collections.Dtos
{
    /// <summary>
    /// 用户收藏编辑用Dto
    /// </summary>
    [AutoMap(typeof(Collection))]
    public class CollectionEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        [Range(1, 255)]
        public int ModuleId { get; set; }

        public long UserId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [Range(1, 255)]
        public int RelativeId { get; set; }

    }
}
