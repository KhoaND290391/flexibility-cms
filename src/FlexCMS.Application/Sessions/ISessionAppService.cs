using System.Threading.Tasks;
using Abp.Application.Services;
using FlexCMS.Sessions.Dto;

namespace FlexCMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
