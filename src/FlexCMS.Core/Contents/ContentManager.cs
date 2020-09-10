using Abp.Domain.Repositories;
using Abp.Events.Bus;
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

        public Task<Content> GetCMSContent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Content> GetCMSContent(string pageName)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertOrUpdateCMSContent(Content content)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Content>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
