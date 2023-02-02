using System;
using System.Net;
using System.Net.Http;

namespace MockHttpClient
{
   /// <summary>
   /// A factory that creates an <see cref="HttpClient"/> of which you can control the response message for the various REST methods.
   /// </summary>
   public static class MockHttpClientFactory
   {
      /// <summary>
      /// Creates an instance of an <see cref="HttpClient"/> of which the various REST methods will return the provided response message.
      /// </summary>
      /// <param name="httpResponseMessage">The response message that will be returned when one of the REST methods is called.</param>
      /// <returns>An <see cref="HttpClient"/></returns>
      public static HttpClient Create(HttpResponseMessage httpResponseMessage)
      {
         if (httpResponseMessage == null)
         {
            throw new ArgumentNullException(nameof(httpResponseMessage));
         }

         var messageHandler = new MockHttpMessageHandler(httpResponseMessage);
         return new HttpClient(messageHandler);
      }

      /// <summary>
      /// Creates an instance of an <see cref="HttpClient"/> of which the various REST methods will return a response message with the provided status code.
      /// </summary>
      /// <param name="httpStatusCode">The status code for the response message that will be returned when one of the REST methods is called.</param>
      /// <returns>An <see cref="HttpClient"/></returns>
      public static HttpClient Create(HttpStatusCode httpStatusCode)
      {
         return Create(new HttpResponseMessage(httpStatusCode));
      }
   }
}
