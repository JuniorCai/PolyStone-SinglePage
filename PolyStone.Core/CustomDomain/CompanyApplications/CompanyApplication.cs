using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.Authorization.Users;
using PolyStone.CustomDomain.Companies;
using PolyStone.CustomDomain.Regions;

namespace PolyStone.CustomDomain.CompanyApplications
{
    public class CompanyApplication:FullAuditedEntity
    {
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public CompanyType CompanyType { get; set; }

        public string License { get; set; }

        public string LegalPerson { get; set; }

        public string FrontImg { get; set; }

        public string BackImg { get; set; }

        public string CompanyName { get; set; }

        public string Business { get; set; }

        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public string LinkMan { get; set; }

        public string Phone { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public AuthStauts AuthStauts { get; set; }
    }

    public enum AuthStauts
    {
        NoPass = -1,
        Pendding = 0,
        Pass=1
    }
}
