using System;
using System.Net;

namespace Application.Errors
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, string errors)
        {
            Code = code;
            Errors = errors;
        }

        public HttpStatusCode Code { get; }
        public string Errors { get; }
    }
}