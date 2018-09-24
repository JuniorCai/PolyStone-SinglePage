using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.CompanyIndustries
{
    public class Industry : FullAuditedEntity
    {
        public string IndustryName { get; set; }

        public string IndustryCode { get; set; }

        public int ParentCode { get; set; }

        public int Sort { get; set; }

        public bool IsShow { get; set; }

        public bool IsActive { get; set; }
        
    }
}
