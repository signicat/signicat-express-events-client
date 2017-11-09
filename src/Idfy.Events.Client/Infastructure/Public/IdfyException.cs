using System;
using System.Net;
using Idfy.Events.Client;

namespace Idfy.Events.Client.Infastructure
{
    public class IdfyException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public IdfyResponse IdfyResponse { get; set; }
        public IdfyError IdfyError { get; set; }
        
        public IdfyException() {}

        public IdfyException(HttpStatusCode httpStatusCode, IdfyError idfyError, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            IdfyError = idfyError;
        }
    }
}