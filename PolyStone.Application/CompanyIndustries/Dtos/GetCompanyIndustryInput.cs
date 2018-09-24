﻿using Abp.Runtime.Validation;


namespace PolyStone.CompanyIndustries.Dtos
{
	/// <summary>
    /// 企业行业关系表查询Dto
    /// </summary>
    public class GetCompanyIndustryInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

		/// <summary>
	    /// 用于排序的默认值
		/// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
			
		
                Sorting = "Id";
            }
        }
    }
}
