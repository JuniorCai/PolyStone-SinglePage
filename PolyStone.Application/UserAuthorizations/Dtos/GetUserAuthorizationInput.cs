using Abp.Runtime.Validation;


namespace PolyStone.UserAuthorizations.Dtos
{
    /// <summary>
    /// 用户第三方绑定查询Dto
    /// </summary>
    public class GetUserAuthorizationInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

        /// <summary>
        /// 模糊查询参数
        /// </summary>
        public string FilterText { get; set; }

        public string OpenId { get; set; }

        public long UserId { get; set; }

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
