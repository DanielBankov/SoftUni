using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using System.Text;

namespace SIS.MvcFramework.Result
{
    public class JsonResult : ActionResult
    {
        public JsonResult(string jsonContent, HttpResponseStatusCode responseStatusCode = HttpResponseStatusCode.Ok) 
            : base(responseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, "application/json"));
            this.Content = Encoding.UTF8.GetBytes(jsonContent);
        }
    }
}
