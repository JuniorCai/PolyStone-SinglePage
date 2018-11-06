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

        public int CodeType { get; set; }

        public string Ip { get; set; }

        public DateTime ExpirationTime { get; set; }

        public CodeVerifyStatus VerifyStatus { get; set; }



    }

    public enum CodeVerifyStatus
    {
        Pendding=0,
        Success=1,
        Failed=2,
        Overdue =3,
    }
}
