using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.CommunityCategories
{
    public class CommunityCategory : FullAuditedEntity
    {
        public string CategoryName { get; set; }

        public int ParentId { get; set; }

        public  int Sort { get; set; }

        public bool IsShow { get; set; }

        public bool IsActive { get; set; }
    }
}
