using Abp.AutoMapper;
using PolyStone.Sessions.Dto;

namespace PolyStone.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}