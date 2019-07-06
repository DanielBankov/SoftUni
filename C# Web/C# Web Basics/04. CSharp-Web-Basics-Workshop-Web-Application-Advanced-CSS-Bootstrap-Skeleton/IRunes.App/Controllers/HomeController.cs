using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;

namespace IRunes.App.ControllersB
{
    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IHttpResponse IndexSlash(IHttpRequest request)
        {
            return Index(request);
        }

        public IHttpResponse Index(IHttpRequest request)
        {
            if (this.IsLoggedIn(request))
            {
                this.ViewData["Username"] = request.Session.GetParameter("username");

                return this.View("Home");
            }

            return this.View(); 
        }
    }
}
