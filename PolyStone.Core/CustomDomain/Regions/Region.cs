using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Regions
{
    public class Region:FullAuditedEntity
    {
        public string RegionName { get; set; }

        public int ParentId { get; set; }

        public int Sort { get; set; }

        public bool IsShow { get; set; }
    }
}
