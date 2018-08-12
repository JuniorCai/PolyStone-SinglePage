using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Categories
{
    public class Category:FullAuditedEntity
    {
        public string CategoryName { get; set; }

        public int IndustryCode { get; set; }

        public string ShortName { get; set; }

        public int ParentId { get; set; }

        public int Sort { get; set; }

        public bool IsShow { get; set; }

        public bool IsActive { get; set; }
    }
}
