using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.UserVerifies
{
    public class UserVerify : FullAuditedEntity
    {
        public string PhoneNumber { get; set; }

        public string Code { get; set; }

        public CodeType CodeType { get; set; }

        public PurposeType Purpose { get; set; }

        public string Ip { get; set; }

        public DateTime ExpirationTime { get; set; }

        public CodeVerifyStatus VerifyStatus { get; set; }



    }

    /// <summary>
    /// 验证码验证状态
    /// </summary>
    public enum CodeVerifyStatus
    {
        Pending=0,
        Success=1,
        Invalid=2,
    }

    /// <summary>
    /// 验证码发送类别
    /// </summary>
    public enum CodeType
    {
        Mobile=1,
        Email=2
    }

    /// <summary>
    /// 验证码用途类别
    /// </summary>
    public enum PurposeType
    {
        /// <summary>
        /// 注册用途
        /// </summary>
        Register=1,
        /// <summary>
        /// 修改密码用途
        /// </summary>
        ResetPassword,
        /// <summary>
        /// 修改手机号用途
        /// </summary>
        ChangePhoneNumber,
        /// <summary>
        /// 其他
        /// </summary>
        Other
    }
}
