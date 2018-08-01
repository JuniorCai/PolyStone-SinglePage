using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.CustomDomain.Products;

namespace PolyStone.CustomDomain.Communities
{
    public class Community : FullAuditedEntity
    {
        public int MemberId { get; set; }

        public int Type { get; set; }

        public string Title { get; set; }

        public string PictureUrls { get; set; }

        public string Detail { get; set; }

        public DateTime RefreshDate { get; set; }

        public VerifyStatus VerifyStatus { get; set; }

        public ReleaseStatus ReleaseStatus { get; set; }

    }
}
