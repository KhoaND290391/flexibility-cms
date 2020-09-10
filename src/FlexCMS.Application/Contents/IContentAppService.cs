using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FlexCMS.Contents.Dto;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    public interface IContentAppService : IApplicationService
    {
        Task<ContentDto> GetCMSContent(int id);
        Task<ContentDto> GetCMSContentByName(string pageName);
        Task<ContentDto> InsertOrUpdateCMSContent(CreateOrUpdateContentDto content);
        Task<ListResultDto<ContentDto>> GetAll();
    }
}
