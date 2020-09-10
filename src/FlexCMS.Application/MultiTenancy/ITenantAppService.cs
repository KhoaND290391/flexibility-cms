using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FlexCMS.MultiTenancy.Dto;

namespace FlexCMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

