using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Modules
{
    public class Module : FullAuditedEntity
    {
        public string ModuleCode { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
