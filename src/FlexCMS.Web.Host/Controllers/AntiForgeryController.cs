using Microsoft.AspNetCore.Antiforgery;
using FlexCMS.Controllers;

namespace FlexCMS.Web.Host.Controllers
{
    public class AntiForgeryController : FlexCMSControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
