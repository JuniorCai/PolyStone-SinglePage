using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.CompanyAuths
{
    public class CompanyAuth:FullAuditedEntity
    {
        public int CompanyId { get; set; }

        public string LegalPerson { get; set; }

        public string FrontImg { get; set; }

        public string BackImg { get; set; }

        public string License { get; set; }
    }
}
