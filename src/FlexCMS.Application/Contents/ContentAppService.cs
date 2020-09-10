using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;
using FlexCMS.Contents.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    [AbpAuthorize]
    public class ContentAppService : FlexCMSAppServiceBase, IContentAppService
    {
        private readonly IContentManager _contentManager;
        public ContentAppService(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public async Task<ListResultDto<ContentDto>> GetAll()
        {
            var contents = await _contentManager.GetAllAsync();
            return new ListResultDto<ContentDto>(contents.MapTo<List<ContentDto>>());
        }

        public async Task<ContentDto> GetCMSContent(int id)
        {
            return await GetContentByIdAsync(id);
        }

        public async Task<ContentDto> GetCMSContentByName(string pageName)
        {
            var content = await _contentManager.GetCMSContentByNameAsync(pageName);
            if (content == null)
            {
                throw new UserFriendlyException("Could not found the content, maybe it's deleted.");
            }
            return content.MapTo<ContentDto>();
        }

        public async Task<ContentDto> InsertOrUpdateCMSContent(CreateOrUpdateContentDto content)
        {
            var tenantId = AbpSession?.TenantId ?? 0;
            var reactor = Content.CreateContent(content.Id, content.PageName, content.PageContent, tenantId);
            var id = await _contentManager.InsertOrUpdateCMSContentAsync(reactor, await GetCurrentUserAsync());
            await SaveAllChangesAsync();
            return await GetContentByIdAsync(id);
        }

        private async Task<ContentDto> GetContentByIdAsync(int id)
        {
            var content = await _contentManager.GetCMSContentByIdAsync(id);
            if (content == null)
            {
                throw new UserFriendlyException("Could not found the content, maybe it's deleted.");
            }
            return content.MapTo<ContentDto>();
        }

        private async Task SaveAllChangesAsync()
        {
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
