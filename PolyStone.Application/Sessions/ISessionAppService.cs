using System.Threading.Tasks;
using Abp.Application.Services;
using PolyStone.Sessions.Dto;

namespace PolyStone.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
