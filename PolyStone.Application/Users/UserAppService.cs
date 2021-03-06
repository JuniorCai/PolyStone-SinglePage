using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using PolyStone.Authorization;
using PolyStone.Authorization.Roles;
using PolyStone.Authorization.Users;
using PolyStone.Roles.Dto;
using PolyStone.Users.Dto;
using Microsoft.AspNet.Identity;

namespace PolyStone.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;

        public UserAppService(
            IRepository<User, long> repository, 
            UserManager userManager, 
            IRepository<Role> roleRepository, 
            RoleManager roleManager)
            : base(repository)
        {
            _userManager = userManager;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        public override async Task<UserDto> Get(EntityDto<long> input)
        {
            var user = await base.Get(input);
            var userRoles = await _userManager.GetRolesAsync(user.Id);
            user.Roles = userRoles.Select(ur => ur).ToArray();
            return user;
        }

        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.Password =
                new PasswordHasher().HashPassword(string.IsNullOrEmpty(input.Password)
                    ? User.DefaultPassword
                    : input.Password);
            user.IsPhoneNumberConfirmed = true;

            //Assign roles
            user.Roles = new Collection<UserRole>();
            foreach (var roleName in input.RoleNames)
            {
                var role = await _roleManager.GetRoleByNameAsync(roleName);
                user.Roles.Add(new UserRole(AbpSession.TenantId, user.Id, role.Id));
            }

            CheckErrors(await _userManager.CreateAsync(user));

            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(user);
        }

        public override async Task<UserDto> Update(UpdateUserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            return await Get(input);
        }


        public async Task<bool> UpdateUser(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);
            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));
            return true;
        }


        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        [AbpAllowAnonymous]
        public async Task<UserDto> IsUserNameExist(string userName)
        {
            UserDto userDto = null;
            IdentityResult result = await _userManager.CheckDuplicateUsernameOrEmailAddressAsync(null, userName, "");
            if (!result.Succeeded)
            {
                var  user = _userManager.FindByNameOrEmailAsync(userName);
                userDto = user.Result.MapTo<UserDto>();
            }
            return userDto;
        }

        [AbpAllowAnonymous]
        public async Task<bool> IsPhoneExist(string phoneNumber)
        {
            UserDto userDto = null;
            IdentityResult result = await _userManager.CheckDuplicatePhoneNumberAsync(null, "", phoneNumber);

            return !result.Succeeded;
        }


        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            return user;
        }

        protected override void MapToEntity(UpdateUserDto input, User user)
        {
            ObjectMapper.Map(input, user);
        }

        protected void MapToEntity(UserDto input, User user)
        {
            ObjectMapper.Map(input, user);
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            var user = Repository.GetAllIncluding(x => x.Roles).FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(user);
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}