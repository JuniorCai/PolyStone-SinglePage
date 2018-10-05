using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Regions
{
    public class Region:FullAuditedEntity
    {
        public string RegionName { get; set; }

        public string RegionCode { get; set; }

        public string ParentCode { get; set; }

        public bool IsShow { get; set; }
    }
}
