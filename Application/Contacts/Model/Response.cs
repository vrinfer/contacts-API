using System.Net;

namespace Application.Contacts
{
    public class Response<TResponse>
    {
        public string ErrorMessage { get; set; }

        public TResponse Data { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
    }
}
