using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using PolyStone.CustomDomain.Companies;

namespace PolyStone.CustomDomain.CompanyIndustries
{
    public class CompanyIndustry : FullAuditedEntity
    {
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int IndustryId { get; set; }

        [ForeignKey("IndustryId")]
        public Industry Industry { get; set; }
    }
}
