using System.Net.Http;

namespace MockHttpClient
{
   internal class CustomHttpClientFactory : ICustomHttpClientFactory
   {
      private static readonly HttpClient _httpClient = new HttpClient();

      public HttpClient CreateClient()
      {
         return _httpClient;
      }
   }
}
