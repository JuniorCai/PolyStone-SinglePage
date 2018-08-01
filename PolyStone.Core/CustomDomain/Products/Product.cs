using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace PolyStone.CustomDomain.Products
{
    public class Product : FullAuditedEntity
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public int CompanyId { get; set; }

        public string ImgUrls { get; set; }

        public string Detail { get; set; }

        public VerifyStatus VerifyStatus { get; set; }

        public ReleaseStatus ReleaseStatus { get; set; }
    }

    public enum VerifyStatus
    {
        NoPass = -1,
        Pendding = 0,
        Pass = 1
    }

    public enum ReleaseStatus
    {
        UnPublished = 0,
        Publish = 1,
        OffLine = 2,
        OverDue = 3
    }
}
