using Abp.Runtime.Validation;


namespace PolyStone.CompanyApplications.Dtos
{
	/// <summary>
    /// 个人会员升级企业申请表查询Dto
    /// </summary>
    public class GetCompanyApplicationInput : PagedAndSortedInputDto, IShouldNormalize
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
