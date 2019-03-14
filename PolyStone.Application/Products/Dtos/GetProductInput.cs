using System;
using Abp.Runtime.Validation;
using PolyStone.CustomDomain.Products;


namespace PolyStone.Products.Dtos
{
	/// <summary>
    /// 产品表查询Dto
    /// </summary>
    public class GetProductInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public int CompanyId { get; set; }

        public string Title { get; set; }

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public ReleaseStatus ReleaseStatus { get; set; }

        public VerifyStatus VerifyStatus { get; set; }
        public DateTime? FromTime { get; set; }

        public DateTime? EndTime { get; set; }


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
