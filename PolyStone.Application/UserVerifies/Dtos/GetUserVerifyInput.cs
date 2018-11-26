using System;
using Abp.Runtime.Validation;
using PolyStone.CustomDomain.UserVerifies;

namespace PolyStone.UserVerifies.Dtos
{
	/// <summary>
    /// 用户验证码查询Dto
    /// </summary>
    public class GetUserVerifyInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public DateTime? CreationTime { get; set; }

        public DateTime? ExpirationTime { get; set; }

        public string PhoneNumber { get; set; }

        public string AuthCode { get; set; }

        public PurposeType PurposeType { get; set; }

        public string Ip { get; set; }

        public CodeVerifyStatus? VerifyStatus { get; set; }


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
