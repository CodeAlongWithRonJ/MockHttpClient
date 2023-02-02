using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MockHttpClient
{
   internal class MockHttpMessageHandler : HttpMessageHandler
   {
      private readonly HttpResponseMessage _httpResponseMessage;

      public MockHttpMessageHandler(HttpResponseMessage httpResponseMessage)
      {
         _httpResponseMessage = httpResponseMessage;
      }

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         return Task.FromResult(_httpResponseMessage);
      }
   }
}
