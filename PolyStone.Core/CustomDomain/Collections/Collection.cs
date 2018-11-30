using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.CustomDomain.Modules;

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

    }
}
