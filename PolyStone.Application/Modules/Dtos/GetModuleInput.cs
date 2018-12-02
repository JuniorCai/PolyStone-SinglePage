using Abp.Runtime.Validation;



namespace PolyStone.Modules.Dtos
{
    /// <summary>
    /// 模块表查询Dto
    /// </summary>
    public class GetModuleInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

        /// <summary>
        /// 模糊查询参数
        /// </summary>
        public string FilterText { get; set; }

        public string ModuleCode { get; set; }

        public string Name { get; set; }

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
