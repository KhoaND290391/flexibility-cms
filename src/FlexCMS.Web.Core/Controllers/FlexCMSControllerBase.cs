using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FlexCMS.Controllers
{
    public abstract class FlexCMSControllerBase: AbpController
    {
        protected FlexCMSControllerBase()
        {
            LocalizationSourceName = FlexCMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
