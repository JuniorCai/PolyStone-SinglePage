using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyStone.Helpers
{
    class UtilsModel
    {
    }

    public class MiniProgramReturnResult
    {
        public CodeStatus Code { get; set; }

        public string ErrMsg { get; set; }

        public string Data { get; set; }
    }

    /// <summary>
    /// 结果码状态
    /// </summary>
    public enum CodeStatus
    {
        /// <summary>
        /// 无效数据
        /// </summary>
        InvalidData=-2,
        /// <summary>
        /// 失败
        /// </summary>
        Failed =-1,
        /// <summary>
        /// 成功
        /// </summary>
        Success=1
    }
}
