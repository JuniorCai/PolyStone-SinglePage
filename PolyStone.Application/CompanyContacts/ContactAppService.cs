using System;
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
using PolyStone.CompanyContacts.Dtos;
using PolyStone.CustomDomain.CompanyContacts;
using PolyStone.CustomDomain.CompanyContacts.Authorization;

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
// Copyright © YoYoCms@China.2018-08-02T16:45:06. All Rights Reserved.
//<生成时间>2018-08-02T16:45:06</生成时间>
	#endregion


namespace PolyStone.CompanyContacts
{
    /// <summary>
    /// 企业联系表服务实现
    /// </summary>
    [AbpAuthorize(ContactAppPermissions.Contact)]


    public class ContactAppService : PolyStoneAppServiceBase, IContactAppService
    {
        private readonly IRepository<Contact, int> _contactRepository;


        private readonly ContactManage _contactManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ContactAppService(IRepository<Contact, int> contactRepository,
            ContactManage contactManage

        )
        {
            _contactRepository = contactRepository;
            _contactManage = contactManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Contact> _contactRepositoryAsNoTrack => _contactRepository.GetAll().AsNoTracking();


        #endregion


        #region 企业联系表管理

        /// <summary>
        /// 根据查询条件获取企业联系表分页列表
        /// </summary>
        public async Task<PagedResultDto<ContactListDto>> GetPagedContactsAsync(GetContactInput input)
        {

            var query = _contactRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            query = query.WhereIf(input.CompanyId > 0, c => c.CompanyId == input.CompanyId);

            var contactCount = await query.CountAsync();

            var contacts = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var contactListDtos = contacts.MapTo<List<ContactListDto>>();
            return new PagedResultDto<ContactListDto>(
                contactCount,
                contactListDtos
            );
        }

        /// <summary>
        /// 通过Id获取企业联系表信息进行编辑或修改 
        /// </summary>
        public async Task<GetContactForEditOutput> GetContactForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetContactForEditOutput();

            ContactEditDto contactEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _contactRepository.GetAsync(input.Id.Value);
                contactEditDto = entity.MapTo<ContactEditDto>();
            }
            else
            {
                contactEditDto = new ContactEditDto();
            }

            output.Contact = contactEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取企业联系表ListDto信息
        /// </summary>
        public async Task<ContactListDto> GetContactByIdAsync(EntityDto<int> input)
        {
            var entity = await _contactRepository.GetAsync(input.Id);

            return entity.MapTo<ContactListDto>();
        }







        /// <summary>
        /// 新增或更改企业联系表
        /// </summary>
        public async Task CreateOrUpdateContactAsync(CreateOrUpdateContactInput input)
        {
            using (var _unitWork = UnitOfWorkManager.Begin())
            {
                int contactId = 0;
                if (input.ContactEditDto.Id.HasValue)
                {
                    await UpdateContactAsync(input.ContactEditDto);
                    contactId = input.ContactEditDto.Id.Value;
                }
                else
                {
                    var model = await CreateContactAsync(input.ContactEditDto);
                    contactId = model.Id.Value;
                }

                if (input.ContactEditDto.IsDefault)
                {
                    await SetContactDefault(input.ContactEditDto.CompanyId, contactId);
                }


                _unitWork.Complete();
            }
        }


        /// <summary>
        /// 设置联系方式为默认
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [AbpAuthorize(ContactAppPermissions.Contact_EditContact)]
        public virtual async Task SetContactDefault(int companyId, int contactId)
        {

            foreach (var contact in _contactRepository.GetAll().Where(c=>c.CompanyId == companyId).ToList())
            {
                contact.IsDefault = false;
                await _contactRepository.UpdateAsync(contact);
            }

            var entity = await _contactRepository.GetAsync(contactId);
            entity.IsDefault = true;
            await _contactRepository.UpdateAsync(entity);

        }

        /// <summary>
        /// 新增企业联系表
        /// </summary>
        [AbpAuthorize(ContactAppPermissions.Contact_CreateContact)]
        public virtual async Task<ContactEditDto> CreateContactAsync(ContactEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Contact>();

            entity.Id = await _contactRepository.InsertAndGetIdAsync(entity);
            return entity.MapTo<ContactEditDto>();
        }

        /// <summary>
        /// 编辑企业联系表
        /// </summary>
        [AbpAuthorize(ContactAppPermissions.Contact_EditContact)]
        public virtual async Task UpdateContactAsync(ContactEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _contactRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _contactRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除企业联系表
        /// </summary>
        [AbpAuthorize(ContactAppPermissions.Contact_DeleteContact)]
        public async Task DeleteContactAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _contactRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除企业联系表
        /// </summary>
        [AbpAuthorize(ContactAppPermissions.Contact_DeleteContact)]
        public async Task BatchDeleteContactAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _contactRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion

    }
}