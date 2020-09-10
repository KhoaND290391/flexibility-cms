using Abp.Domain.Repositories;
using Abp.Events.Bus;
using FlexCMS.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    public class ContentManager : IContentManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IContentPolicy _contentPolicy;
        private readonly IRepository<Content, int> _contentRepository;

        public ContentManager(IContentPolicy contentPolicy, IRepository<Content, int> contentRepository)
        {
            _contentPolicy = contentPolicy;
            _contentRepository = contentRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<Content> GetCMSContentByIdAsync(int id)
        {
            return await _contentRepository.FirstOrDefaultAsync(id);
        }

        public async Task<Content> GetCMSContentByNameAsync(string pageName)
        {
            return await _contentRepository.FirstOrDefaultAsync(o => o.PageName.Equals(pageName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<int> InsertOrUpdateCMSContentAsync(Content content, User creator)
        {
            await _contentPolicy.CheckUserAbleToReactTheContent(content, creator);
            return await _contentRepository.InsertOrUpdateAndGetIdAsync(content);
        }

        public async Task<IList<Content>> GetAllAsync()
        {
            return await _contentRepository.GetAllListAsync();
        }
    }
}
