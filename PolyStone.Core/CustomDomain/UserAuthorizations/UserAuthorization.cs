using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

namespace PolyStone.CustomDomain.UserAuthorizations
{
    public class UserAuthorization:FullAuditedEntity
    {
        public string OpenId { get; set; }

        public long UserId { get; set; }

        public string ThirdName { get; set; }

        public bool IsActive { get; set; }

    }
}
