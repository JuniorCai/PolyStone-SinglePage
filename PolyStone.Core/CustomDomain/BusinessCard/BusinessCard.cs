using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.BusinessCard
{
    public class BusinessCard: FullAuditedEntity
    {
        public long UserId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string WxNumber { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Position { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Introduction { get; set; }

    }
}
