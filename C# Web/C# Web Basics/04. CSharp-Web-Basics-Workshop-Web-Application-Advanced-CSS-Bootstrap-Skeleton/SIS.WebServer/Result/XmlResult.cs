using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using System.Text;

namespace SIS.MvcFramework.Result
{
    public class XmlResult : ActionResult
    {
        public XmlResult(string xmlContent, HttpResponseStatusCode responseStatusCode = HttpResponseStatusCode.Ok)
            : base(responseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, "application/xml"));
            this.Content = Encoding.UTF8.GetBytes(xmlContent);
        }
    }
}
