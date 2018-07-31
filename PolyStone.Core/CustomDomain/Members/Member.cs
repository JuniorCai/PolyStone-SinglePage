using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Members
{
    public class Member : FullAuditedEntity
    {
        public string AccountName { get; set; }

        public string  FullName { get; set; }

        public string NickName { get; set; }

        public string Phone  { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
