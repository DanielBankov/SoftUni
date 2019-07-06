using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Responses.Contracts;
using System;
using System.Text;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }

        public HttpResponse(HttpResponseStatusCode statusCode) : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get ; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get ; set ; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            byte[] httpResponseByteWithoutBody = Encoding.UTF8.GetBytes(this.ToString());
            byte[] httpResponseByteWithBody = new byte[httpResponseByteWithoutBody.Length + this.Content.Length];

            for (int i = 0; i < httpResponseByteWithoutBody.Length; i++)
            {
                httpResponseByteWithBody[i] = httpResponseByteWithoutBody[i];
            }

            for (int i = 0; i < httpResponseByteWithBody.Length - httpResponseByteWithoutBody.Length; i++)
            {
                httpResponseByteWithBody[i + httpResponseByteWithoutBody.Length] = this.Content[i];
            }

            return httpResponseByteWithBody;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
             .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetStatusLine()}")
             .Append(GlobalConstants.HttpNewLine)
             .Append(this.Headers)
             .Append(GlobalConstants.HttpNewLine)
             .Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}
