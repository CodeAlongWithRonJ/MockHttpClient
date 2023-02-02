# MockHttpClient
MockHttpClient makes it possible to mock the HttpResponseMessage that is returned by HttpClient. This allows you to unit test classes that use HttpClient.

## How to use it
MockHttpClient is made with a focus on dependency injection. To use it in your application, make sure to register it with your DI container. The interface that is used to create an HttpClient is named *ICustomHttpClientFactory* and the implementation is named *CustomHttpClientFactory*. The dependency can be registered with a Singleton scope.

Say you use the default dependency injection container of .NET Core. In that case you can register the factory like this:

    services.AddSingleton<ICustomHttpClientFactory, CustomHttpClientFactory>();

Now that it is registered in your DI container, you can inject *ICustomHttpClientFactory* and use it to create an HttpClient. An example of this:

    public class PseudoCodeClient
    {
       private readonly ICustomHttpClientFactory _httpClientFactory;

       public PseudoCodeClient(ICustomHttpClientFactory httpClientFactory)
       {
          _httpClientFactory = httpClientFactory;
       }

       public async Task<bool> ReturnsOkResponseAsync()
       {
          var client = _httpClientFactory.CreateClient();
          var response = await client.GetAsync("http://www.api.com");

          return response.IsSuccessStatusCode;
       }
    }

To mock the response that is returned by HttpClient in your unit tests, you can use the *MockHttpClientFactory*. This factory has two Create methods that return an HttpClient. For example:

    var httpClient = MockHttpClientFactory.Create(HttpStatusCode.OK);

This would return an HttpClient that returns a response message with an OK status code, regardless of the REST method of HttpClient that you execute.

Lastly you can use a mocking framework to create a mock for *ICustomHttpClientFactory* and then let the mock return the httpClient variable when its CreateClient method is called.

## Classes

### ICustomHttpClientFactory / CustomHttpClientFactory

#### Methods
CreateClient() : HttpClient

### MockHttpClientFactory

#### Methods
Create(HttpResponseMessage) : HttpClient
Create(HttpStatusCode) : HttpClient
Create(HttpStatusCode, string) : HttpClient
Create<T>(HttpStatusCode, T) : HttpClient