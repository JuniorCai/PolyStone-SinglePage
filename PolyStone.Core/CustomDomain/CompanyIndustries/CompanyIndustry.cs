using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;
using PolyStone.CustomDomain.Companies;

namespace PolyStone.CustomDomain.CompanyIndustries
{
    public class CompanyIndustry : FullAuditedEntity
    {
        public int CompanyId { get; set; }

        [JsonIgnore]
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public int IndustryId { get; set; }

        [ForeignKey("IndustryId")]
        public virtual Industry Industry { get; set; }
    }
}
