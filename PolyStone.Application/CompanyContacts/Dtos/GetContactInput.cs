using Abp.Runtime.Validation;


namespace PolyStone.CompanyContacts.Dtos
{
	/// <summary>
    /// 企业联系表查询Dto
    /// </summary>
    public class GetContactInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public int CompanyId { get; set; }

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
