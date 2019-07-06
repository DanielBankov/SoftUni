﻿using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using System;
using System.Globalization;
using System.Text;

namespace Demo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //var request =
            //    "POST /url/asd?name=john&id=1#fragment HTTP/1.1\r\n"
            //    + "Authorization: Basic 23112132123\r\n"
            //    + "Date: " + DateTime.Now + "\r\n"
            //    + "Host: localhost:5000\r\n"
            //    + "\r\n"
            //    + "username=johndoe&password=123";
            //HttpRequest httpRequest = new HttpRequest(request);

            HttpResponse response = new HttpResponse(HttpResponseStatusCode.InternalServerError);
            response.AddHeader(new HttpHeader("Host", "localgost:5000"));
            response.AddHeader(new HttpHeader("Date", DateTime.Now.ToString(CultureInfo.CurrentCulture)));
            response.Content = Encoding.UTF8.GetBytes("<h1>Hello web</h1>");
            Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));

            ;
        }
    }
}
