using System.Net.Http;

namespace MockHttpClient
{
   public interface ICustomHttpClientFactory
   {
      HttpClient CreateClient();
   }
}
