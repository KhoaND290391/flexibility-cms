using System.Threading.Tasks;
using Abp.Application.Services;
using FlexCMS.Authorization.Accounts.Dto;

namespace FlexCMS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
