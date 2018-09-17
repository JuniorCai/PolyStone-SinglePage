using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.CustomDomain.Products;

namespace PolyStone.CustomDomain.Companies
{
    public class Company : FullAuditedEntity
    {
        public string Logo { get; set; }

        public string CompanyName { get; set; }

        public CompanyType CompanyType { get; set; }

        public int MemberId { get; set; }

        public bool IsAuthed { get; set; }

        public string Bussiness { get; set; }

        public string Introduction { get; set; }

        public int RegionId { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public enum CompanyType
    {
        /// <summary>
        /// 石材企业
        /// </summary>
        Enterprise = 0,

        /// <summary>
        /// 石材店铺
        /// </summary>
        Shop=1,
    }
}
