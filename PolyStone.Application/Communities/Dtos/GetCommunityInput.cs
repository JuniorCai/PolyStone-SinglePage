using System;
using Abp.Runtime.Validation;
using PolyStone.CustomDomain.Products;


namespace PolyStone.Communities.Dtos
{
	/// <summary>
    /// 圈子信息表查询Dto
    /// </summary>
    public class GetCommunityInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

        public int Id { get; set; }

        public string Title { get; set; }

        public int CommunityCategoryId { get; set; }

        public int UserId { get; set; }

        public VerifyStatus VerifyStatus { get; set; }

        public ReleaseStatus ReleaseStatus { get; set; }

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
