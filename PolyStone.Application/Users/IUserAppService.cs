using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PolyStone.Roles.Dto;
using PolyStone.Users.Dto;

namespace PolyStone.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task<UserDto> IsUserNameExist(string userName);
        Task<bool> IsPhoneExist(string phoneNumber);

        Task<bool> UpdateUser(UserDto input);
    }
}