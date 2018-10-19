using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Modules;


namespace PolyStone.Modules.Dtos
{
    /// <summary>
    /// 模块表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Module))]
    public class ModuleListDto : EntityDto<int>
    {
        /// <summary>
        /// 编码
        /// </summary>
        [DisplayName("编码")]
        public string ModuleCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
