using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.Authorization.Users;
using PolyStone.CustomDomain.CompanyAuths;
using PolyStone.CustomDomain.CompanyContacts;
using PolyStone.CustomDomain.CompanyIndustries;
using PolyStone.CustomDomain.Products;
using PolyStone.CustomDomain.Regions;

namespace PolyStone.CustomDomain.Companies
{
    public class Company : FullAuditedEntity
    {
        public string Logo { get; set; }

        public string CompanyName { get; set; }

        public string ShortName { get; set; }

        public CompanyType CompanyType { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public bool IsAuthed { get; set; }

        public string Business { get; set; }

        public string Introduction { get; set; }

        public string RegionCode { get; set; }

        [ForeignKey("RegionCode")]
        public virtual Region Region { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public virtual CompanyAuth CompanyAuth { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<CompanyIndustry> Industries { get; set; }

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
