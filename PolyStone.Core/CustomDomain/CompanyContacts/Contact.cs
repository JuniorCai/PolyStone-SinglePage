using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.CompanyContacts
{
    public class Contact : FullAuditedEntity
    {
        public int CompanyId { get; set; }

        public string LinkMan { get; set; }

        public string Phone { get; set; }

        public string Tel { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public bool IsDefault { get; set; }
    }
}
