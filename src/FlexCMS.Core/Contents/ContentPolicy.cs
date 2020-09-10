
using Abp.Configuration;
using Abp.Domain.Repositories;
using FlexCMS.Authorization.Users;
using System;
using System.Threading.Tasks;

namespace FlexCMS.Contents
{
    public class ContentPolicy : IContentPolicy
    {
        private readonly IRepository<Content> _contentRepository;
        private readonly ISettingManager _settingManager;
        public ContentPolicy(
            IRepository<Content> contentRepository,
            ISettingManager settingManager)
        {
            _contentRepository = contentRepository;
            _settingManager = settingManager;
        }
        public async Task CheckUserAbleToReactTheContent(Content content, User user)
        {
            if (content == null) { throw new ArgumentNullException("content"); }
            if (user == null) { throw new ArgumentNullException("user"); }
            await CheckUserPermissionOnCms(user);
            await CheckPageContentViolentXSS(content);
            await CheckPageContentViolentSqlInjection(content);
            await CheckContentInProcessing(content, user);

        }
        private async Task CheckPageContentViolentXSS(Content content)
        {

        }

        private async Task CheckPageContentViolentSqlInjection(Content content)
        {

        }

        private async Task CheckUserPermissionOnCms(User user)
        {

        }
        private async Task CheckContentInProcessing(Content content, User user)
        {

        }

    }
}
