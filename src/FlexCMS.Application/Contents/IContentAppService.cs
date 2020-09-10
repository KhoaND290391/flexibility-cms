using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FlexCMS.Contents.Dto;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    public interface IContentAppService : IApplicationService
    {
        Task<ContentDto> GetCMSContentAsync(int id);
        Task<ContentDto> GetCMSContentAsync(string pageName);
        Task<int> InsertOrUpdateCMSContentAsync(CreateContentDto content);
        Task<ListResultDto<ContentDto>> GetAllAsync();
    }
}
