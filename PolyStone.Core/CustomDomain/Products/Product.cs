using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.CustomDomain.Categories;
using PolyStone.CustomDomain.Companies;

namespace PolyStone.CustomDomain.Products
{
    public class Product : FullAuditedEntity
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public string ImgUrls { get; set; }

        public string Detail { get; set; }

        public VerifyStatus VerifyStatus { get; set; }

        public ReleaseStatus ReleaseStatus { get; set; }
    }

    public enum VerifyStatus
    {
        Invalid = -1,
        Pending = 0,
        Pass = 1,
        NoPass = 2

    }

    public enum ReleaseStatus
    {
        Invalid = -1,
        UnPublished = 0,
        Publish = 1,
        OffLine = 2,
        OverDue = 3
    }
}
