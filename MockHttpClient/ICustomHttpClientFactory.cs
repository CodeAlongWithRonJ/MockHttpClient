using System.Net.Http;

namespace MockHttpClient
{
   /// <summary>
   /// A factory that allows the creation of an <see cref="HttpClient"/> through dependency injection.
   /// </summary>
   public interface ICustomHttpClientFactory
   {
      /// <summary>
      /// Creates an instance of an <see cref="HttpClient"/>.
      /// </summary>
      /// <returns>An <see cref="HttpClient"/></returns>
      HttpClient CreateClient();
   }
}
