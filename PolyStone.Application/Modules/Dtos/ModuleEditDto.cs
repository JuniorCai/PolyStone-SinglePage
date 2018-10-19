using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Modules;


namespace PolyStone.Modules.Dtos
{
    /// <summary>
    /// 模块表编辑用Dto
    /// </summary>
    [AutoMap(typeof(Module))]
    public class ModuleEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DisplayName("编码")]
        [Required]
        [MaxLength(10)]
        public string ModuleCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        [Required]
        public bool IsActive { get; set; }

    }
}
