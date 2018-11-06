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

    public enum CodeVerifyStatus
    {
        Pending=0,
        Success=1,
        Invalid=2,
    }

    public enum CodeType
    {
        Mobile=1,
        Email=2
    }

    public enum PurposeType
    {
        Register=1,
        ResetPassword,
        ChangePhoneNumber
    }
}
