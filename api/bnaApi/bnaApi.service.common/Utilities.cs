using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace bnaApi.service.common
{
    public class Utilities : IUtilities
    {
        public HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, HttpStatusCode status, object data = null)
        {
            var response = request.CreateResponse(status);

            if (data != null)
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                var sb = new StringBuilder();
                var writer = new StringWriter(sb);
                serializer.Serialize(writer, data);
                response.Content = new StringContent(sb.ToString());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return response;
        }
    }
}
