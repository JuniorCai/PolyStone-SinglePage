using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.MultiTenancy.Dto;

namespace PolyStone.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
