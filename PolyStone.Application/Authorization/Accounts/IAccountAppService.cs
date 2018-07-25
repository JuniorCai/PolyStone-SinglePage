using System.Threading.Tasks;
using Abp.Application.Services;
using PolyStone.Authorization.Accounts.Dto;

namespace PolyStone.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
