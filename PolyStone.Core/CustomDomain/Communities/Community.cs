using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using PolyStone.Authorization.Users;
using PolyStone.CustomDomain.CommunityCategories;
using PolyStone.CustomDomain.Products;

namespace PolyStone.CustomDomain.Communities
{
    public class Community : FullAuditedEntity
    {
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int CommunityCategoryId { get; set; }

        [ForeignKey("CommunityCategoryId")]
        public virtual CommunityCategory CommunityCategory { get; set; }

        public string Title { get; set; }

        public string ImgUrls { get; set; }

        public string Detail { get; set; }

        public DateTime RefreshDate { get; set; }

        public VerifyStatus VerifyStatus { get; set; }

        public ReleaseStatus ReleaseStatus { get; set; }

    }
}
