using Abp.Runtime.Validation;


namespace PolyStone.Companies.Dtos
{
	/// <summary>
    /// 企业表查询Dto
    /// </summary>
    public class GetCompanyInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public string CompanyName { get; set; }

        public bool? IsAuthed { get; set; }

        public bool? IsActive { get; set; }

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
