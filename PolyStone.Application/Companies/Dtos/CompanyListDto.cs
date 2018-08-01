using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using PolyStone.CustomDomain.Companies;


namespace PolyStone.Companies.Dtos
{
	/// <summary>
    /// 企业表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Company))]
    public class CompanyListDto : EntityDto<int>
    {
        public      string CompanyName { get; set; }
        public      int MemberId { get; set; }
        public      bool IsAuthed { get; set; }
        public      string Bussiness { get; set; }
        public      string Introduction { get; set; }
        public      int RegionId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
