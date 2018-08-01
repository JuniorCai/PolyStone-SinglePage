﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Collections
{
    public class Collection : FullAuditedEntity
    {
        public int Type { get; set; }

        public string Name { get; set; }

        public int RelativeId { get; set; }

    }
}