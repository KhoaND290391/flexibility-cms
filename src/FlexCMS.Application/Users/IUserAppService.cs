using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FlexCMS.Roles.Dto;
using FlexCMS.Users.Dto;

namespace FlexCMS.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
