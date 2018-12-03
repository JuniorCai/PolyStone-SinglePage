using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using PolyStone.CustomDomain.Modules;
using PolyStone.CustomDomain.Modules.Authorization;
using PolyStone.Modules.Dtos;

namespace PolyStone.Modules
{
    /// <summary>
    /// 模块表服务实现
    /// </summary>


    public class ModuleAppService : PolyStoneAppServiceBase, IModuleAppService
    {
        private readonly IRepository<Module, int> _moduleRepository;


        private readonly ModuleManage _moduleManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ModuleAppService(IRepository<Module, int> moduleRepository,
            ModuleManage moduleManage

        )
        {
            _moduleRepository = moduleRepository;
            _moduleManage = moduleManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Module> _moduleRepositoryAsNoTrack => _moduleRepository.GetAll().AsNoTracking();


        #endregion


        #region 模块表管理

        /// <summary>
        /// 根据查询条件获取模块表分页列表
        /// </summary>
        public async Task<PagedResultDto<ModuleListDto>> GetPagedModulesAsync(GetModuleInput input)
        {

            var query = _moduleRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件
            query = query.WhereIf(!input.ModuleCode.IsNullOrEmpty(), m => m.ModuleCode == input.ModuleCode)
                .WhereIf(!input.Name.IsNullOrEmpty(), m => m.Name == input.Name)
                .WhereIf(input.IsActive.HasValue, m => m.IsActive == input.IsActive.Value);

            var moduleCount = await query.CountAsync();

            var modules = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var moduleListDtos = modules.MapTo<List<ModuleListDto>>();
            return new PagedResultDto<ModuleListDto>(
                moduleCount,
                moduleListDtos
            );
        }

        /// <summary>
        /// 通过Id获取模块表信息进行编辑或修改 
        /// </summary>
        public async Task<GetModuleForEditOutput> GetModuleForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetModuleForEditOutput();

            ModuleEditDto moduleEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _moduleRepository.GetAsync(input.Id.Value);
                moduleEditDto = entity.MapTo<ModuleEditDto>();
            }
            else
            {
                moduleEditDto = new ModuleEditDto();
            }

            output.Module = moduleEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取模块表ListDto信息
        /// </summary>
        public async Task<ModuleListDto> GetModuleByIdAsync(EntityDto<int> input)
        {
            var entity = await _moduleRepository.GetAsync(input.Id);

            return entity.MapTo<ModuleListDto>();
        }






        /// <summary>
        /// 新增或更改模块表
        /// </summary>
        public async Task CreateOrUpdateModuleAsync(CreateOrUpdateModuleInput input)
        {
            if (input.ModuleEditDto.Id.HasValue)
            {
                await UpdateModuleAsync(input.ModuleEditDto);
            }
            else
            {
                await CreateModuleAsync(input.ModuleEditDto);
            }
        }

        /// <summary>
        /// 新增模块表
        /// </summary>
        [AbpAuthorize(ModuleAppPermissions.Module_CreateModule)]
        public virtual async Task<ModuleEditDto> CreateModuleAsync(ModuleEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Module>();

            entity = await _moduleRepository.InsertAsync(entity);
            return entity.MapTo<ModuleEditDto>();
        }

        /// <summary>
        /// 编辑模块表
        /// </summary>
        [AbpAuthorize(ModuleAppPermissions.Module_EditModule)]
        public virtual async Task UpdateModuleAsync(ModuleEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _moduleRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _moduleRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除模块表
        /// </summary>
        [AbpAuthorize(ModuleAppPermissions.Module_DeleteModule)]
        public async Task DeleteModuleAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _moduleRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除模块表
        /// </summary>
        [AbpAuthorize(ModuleAppPermissions.Module_DeleteModule)]
        public async Task BatchDeleteModuleAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _moduleRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
    }
}
