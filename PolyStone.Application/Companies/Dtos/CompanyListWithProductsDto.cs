using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;
using PolyStone.Authorization.Users;
using PolyStone.CompanyAuthes.Dtos;
using PolyStone.CompanyContacts.Dtos;
using PolyStone.CompanyIndustries.Dtos;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.CompanyContacts;
using PolyStone.CustomDomain.CompanyIndustries;
using PolyStone.CustomDomain.Products;
using PolyStone.Products.Dtos;
using PolyStone.Regions.Dtos;
using PolyStone.Users.Dto;


namespace PolyStone.Companies.Dtos
{
    /// <summary>
    /// 企业表列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Company))]
    public class CompanyListWithProductsDto : CompanyListDto
    {
        public ICollection<ProductListDto> Products { get; set; }
    }
}
