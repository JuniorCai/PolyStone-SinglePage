using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.CustomDomain.Communities;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.Modules;
using PolyStone.CustomDomain.Products;

namespace PolyStone.CustomDomain.Collections
{
    public class Collection : FullAuditedEntity
    {
        public int ModuleId { get; set; }

        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }

        public long UserId { get; set; }

        public string Title { get; set; }

        public int RelativeId { get; set; }

        [ForeignKey("RelativeId")]
        public virtual Product Product { get; set; }

        [ForeignKey("RelativeId")]
        public virtual Company Company { get; set; }

        [ForeignKey("RelativeId")]
        public virtual Community Community { get; set; }


    }
}
