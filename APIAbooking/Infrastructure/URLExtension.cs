using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Infrastructure
{
    public static class URLExtension
    {

        public static string PathAndQuery(this HttpRequest request) =>
           request.QueryString.HasValue
           ? $"{request.Path}{request.QueryString}"
           : request.Path.ToString();

    }
}


