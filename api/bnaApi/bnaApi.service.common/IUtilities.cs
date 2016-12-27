using System.Net;
using System.Net.Http;

namespace bnaApi.service.common
{
    public interface IUtilities
    {
        HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, HttpStatusCode status, object data = null);
    }
}