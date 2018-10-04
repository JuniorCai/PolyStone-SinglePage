using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;
using PolyStone.CustomDomain.Companies;

namespace PolyStone.CustomDomain.CompanyAuths
{
    public class CompanyAuth:FullAuditedEntity
    {
        [Key]
        public int CompanyId { get; set; }

        [JsonIgnore]
        public virtual Company Company { get; set; }

        public string LegalPerson { get; set; }

        public string FrontImg { get; set; }

        public string BackImg { get; set; }

        public string License { get; set; }
    }
}
