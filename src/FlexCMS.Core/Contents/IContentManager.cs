using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    public interface IContentManager : IDomainService
    {
        Task<Content> GetCMSContent(int id);
        Task<Content> GetCMSContent(string pageName);
        Task<int> InsertOrUpdateCMSContent(Content content);
        Task<IEnumerable<Content>> GetAll();
    }
}
