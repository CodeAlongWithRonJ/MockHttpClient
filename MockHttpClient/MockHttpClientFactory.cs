using System;
using System.Net;
using System.Net.Http;

namespace MockHttpClient
{
   public static class MockHttpClientFactory
   {
      public static HttpClient Create(HttpResponseMessage httpResponseMessage)
      {
         if (httpResponseMessage == null)
         {
            throw new ArgumentNullException(nameof(httpResponseMessage));
         }

         var messageHandler = new MockHttpMessageHandler(httpResponseMessage);
         return new HttpClient(messageHandler);
      }

      public static HttpClient Create(HttpStatusCode httpStatusCode)
      {
         return Create(new HttpResponseMessage(httpStatusCode));
      }
   }
}
