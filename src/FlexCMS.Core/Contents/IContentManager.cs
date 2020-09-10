using Abp.Domain.Services;
using FlexCMS.Authorization.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    public interface IContentManager : IDomainService
    {
        Task<Content> GetCMSContentByIdAsync(int id);
        Task<Content> GetCMSContentByNameAsync(string pageName);
        Task<int> InsertOrUpdateCMSContentAsync(Content content, User creator);
        Task<IList<Content>> GetAllAsync();
    }
}
