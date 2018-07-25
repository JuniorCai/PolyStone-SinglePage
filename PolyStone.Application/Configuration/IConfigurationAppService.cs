using System.Threading.Tasks;
using Abp.Application.Services;
using PolyStone.Configuration.Dto;

namespace PolyStone.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}