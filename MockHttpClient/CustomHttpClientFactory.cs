using System.Net.Http;

namespace MockHttpClient
{
   /// <inheritdoc/>
   public class CustomHttpClientFactory : ICustomHttpClientFactory
   {
      private static readonly HttpClient _httpClient = new HttpClient();

      /// <inheritdoc/>
      public HttpClient CreateClient()
      {
         return _httpClient;
      }
   }
}
