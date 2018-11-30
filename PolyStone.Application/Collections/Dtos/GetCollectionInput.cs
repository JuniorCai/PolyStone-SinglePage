using Abp.Runtime.Validation;


namespace PolyStone.Collections.Dtos
{
	/// <summary>
    /// 用户收藏查询Dto
    /// </summary>
    public class GetCollectionInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public long UserId { get; set; }

        public int ModuleId { get; set; }

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
