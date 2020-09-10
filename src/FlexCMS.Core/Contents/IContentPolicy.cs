using Abp.Domain.Services;
using FlexCMS.Authorization.Users;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    public interface IContentPolicy: IDomainService
    {
        Task CheckUserAbleToReactTheContent(Content content, User user);
    }
}
