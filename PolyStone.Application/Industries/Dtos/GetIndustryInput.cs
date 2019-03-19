using Abp.Runtime.Validation;

namespace PolyStone.Industries.Dtos
{
	/// <summary>
    /// 企业行业表查询Dto
    /// </summary>
    public class GetIndustryInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsShow { get; set; }

        public string IndustryCode { get; set; }

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
