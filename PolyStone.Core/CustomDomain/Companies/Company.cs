using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Companies
{
    public class Company : FullAuditedEntity
    {
        public string CompanyName { get; set; }

        public int MemberId { get; set; }

        public bool IsAuthed { get; set; }

        public string Bussiness { get; set; }

        public string Introduction { get; set; }

        public int RegionId { get; set; }


    }
}
