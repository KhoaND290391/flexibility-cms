using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using FlexCMS.Contents.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    [AbpAuthorize]
    public class ContentAppService : FlexCMSAppServiceBase, IContentAppService
    {
        private readonly IContentManager _contentManager;
        private readonly IRepository<Content, int> _contentRepository;
        public ContentAppService(IContentManager contentManager, IRepository<Content, int> contentRepository)
        {
            _contentManager = contentManager;
            _contentRepository = contentRepository;
        }

        public async Task<ListResultDto<ContentDto>> GetAllAsync()
        {
            var contents = await _contentRepository.GetAll().ToListAsync();
            return new ListResultDto<ContentDto>(contents.MapTo<List<ContentDto>>());
        }

        public async Task<ContentDto> GetCMSContentAsync(int id)
        {
            var content = await _contentRepository.FirstOrDefaultAsync(o => o.Id == id);
            if(content == null)
            {
                throw new UserFriendlyException("Could not found the content, maybe it's deleted.");
            }
            return content.MapTo<ContentDto>();
        }

        public async Task<ContentDto> GetCMSContentAsync(string pageName)
        {
            var content = await _contentRepository.FirstOrDefaultAsync(o => o.PageName.Equals(pageName, StringComparison.OrdinalIgnoreCase));
            if (content == null)
            {
                throw new UserFriendlyException("Could not found the content, maybe it's deleted.");
            }
            return content.MapTo<ContentDto>();
        }

        public async Task<int> InsertOrUpdateCMSContentAsync(CreateContentDto content)
        {
            var reactor = Content.CreateContent(content.PageName, content.PageContent, AbpSession.GetTenantId());
            var successCode =  await _contentManager.InsertOrUpdateCMSContent(reactor);
            await SaveAllChangesAsync();
            return successCode;
        }


        private async Task SaveAllChangesAsync()
        {
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
