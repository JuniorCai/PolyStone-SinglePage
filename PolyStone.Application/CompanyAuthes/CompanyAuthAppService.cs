using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using PolyStone.CompanyAuthes.Dtos;
using PolyStone.CustomDomain.CompanyAuths;
using PolyStone.CustomDomain.CompanyAuths.Authorization;

#region 代码生成器相关信息_ABP Code Generator Info
   //你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
   //我的邮箱:werltm@hotmail.com
   // 官方网站:"http://www.yoyocms.com"
 // 交流QQ群：104390185  
 //微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2018-08-02T17:18:34. All Rights Reserved.
//<生成时间>2018-08-02T17:18:34</生成时间>
	#endregion


namespace PolyStone.CompanyAuthes
{
    /// <summary>
    /// 企业资质表服务实现
    /// </summary>
    [AbpAuthorize(CompanyAuthAppPermissions.CompanyAuth)]


    public class CompanyAuthAppService : PolyStoneAppServiceBase, ICompanyAuthAppService
    {
        private readonly IRepository<CompanyAuth, int> _companyAuthRepository;


        private readonly CompanyAuthManage _companyAuthManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyAuthAppService(IRepository<CompanyAuth, int> companyAuthRepository,
            CompanyAuthManage companyAuthManage

        )
        {
            _companyAuthRepository = companyAuthRepository;
            _companyAuthManage = companyAuthManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<CompanyAuth> _companyAuthRepositoryAsNoTrack =>
            _companyAuthRepository.GetAll().AsNoTracking();


        #endregion


        #region 企业资质表管理

        /// <summary>
        /// 根据查询条件获取企业资质表分页列表
        /// </summary>
        public async Task<PagedResultDto<CompanyAuthListDto>> GetPagedCompanyAuthsAsync(GetCompanyAuthInput input)
        {

            var query = _companyAuthRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var companyAuthCount = await query.CountAsync();

            var companyAuths = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var companyAuthListDtos = companyAuths.MapTo<List<CompanyAuthListDto>>();
            return new PagedResultDto<CompanyAuthListDto>(
                companyAuthCount,
                companyAuthListDtos
            );
        }

        /// <summary>
        /// 通过Id获取企业资质表信息进行编辑或修改 
        /// </summary>
        public async Task<GetCompanyAuthForEditOutput> GetCompanyAuthForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCompanyAuthForEditOutput();

            CompanyAuthEditDto companyAuthEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _companyAuthRepository.GetAsync(input.Id.Value);
                companyAuthEditDto = entity.MapTo<CompanyAuthEditDto>();
            }
            else
            {
                companyAuthEditDto = new CompanyAuthEditDto();
            }

            output.CompanyAuth = companyAuthEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取企业资质表ListDto信息
        /// </summary>
        public async Task<CompanyAuthListDto> GetCompanyAuthByIdAsync(EntityDto<int> input)
        {
            var entity = await _companyAuthRepository.GetAsync(input.Id);

            return entity.MapTo<CompanyAuthListDto>();
        }







        /// <summary>
        /// 新增或更改企业资质表
        /// </summary>
        public async Task CreateOrUpdateCompanyAuthAsync(CreateOrUpdateCompanyAuthInput input)
        {
            if (input.CompanyAuthEditDto.Id.HasValue)
            {
                await UpdateCompanyAuthAsync(input.CompanyAuthEditDto);
            }
            else
            {
                await CreateCompanyAuthAsync(input.CompanyAuthEditDto);
            }
        }

        /// <summary>
        /// 新增企业资质表
        /// </summary>
        [AbpAuthorize(CompanyAuthAppPermissions.CompanyAuth_CreateCompanyAuth)]
        public virtual async Task<CompanyAuthEditDto> CreateCompanyAuthAsync(CompanyAuthEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<CompanyAuth>();

            entity = await _companyAuthRepository.InsertAsync(entity);
            return entity.MapTo<CompanyAuthEditDto>();
        }

        /// <summary>
        /// 编辑企业资质表
        /// </summary>
        [AbpAuthorize(CompanyAuthAppPermissions.CompanyAuth_EditCompanyAuth)]
        public virtual async Task UpdateCompanyAuthAsync(CompanyAuthEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _companyAuthRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _companyAuthRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除企业资质表
        /// </summary>
        [AbpAuthorize(CompanyAuthAppPermissions.CompanyAuth_DeleteCompanyAuth)]
        public async Task DeleteCompanyAuthAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _companyAuthRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除企业资质表
        /// </summary>
        [AbpAuthorize(CompanyAuthAppPermissions.CompanyAuth_DeleteCompanyAuth)]
        public async Task BatchDeleteCompanyAuthAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _companyAuthRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


    }
}
