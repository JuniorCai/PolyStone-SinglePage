using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;
using PolyStone.CustomDomain.Companies;

namespace PolyStone.CustomDomain.CompanyContacts
{
    public class Contact : FullAuditedEntity
    {
        public int CompanyId { get; set; }

        [JsonIgnore]
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public string LinkMan { get; set; }

        public string Phone { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public bool IsDefault { get; set; }
    }
}
