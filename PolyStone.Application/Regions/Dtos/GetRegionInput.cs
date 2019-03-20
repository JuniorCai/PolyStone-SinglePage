using Abp.Runtime.Validation;


namespace PolyStone.Regions.Dtos
{
	/// <summary>
    /// 地区表查询Dto
    /// </summary>
    public class GetRegionInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 地区编码
		/// </summary>
		public string RegionCode { get; set; }

        

		/// <summary>
	    /// 用于排序的默认值
		/// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
			
		
                Sorting = "RegionCode";
            }
        }
    }
}
