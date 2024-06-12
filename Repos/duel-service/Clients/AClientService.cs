using Microsoft.Extensions.Options;

namespace Clients;

public class AClientService
{
    
    protected readonly HttpClient _httpClient;

    public AClientService(HttpClient httpClient, IOptions<ServiceOptions> options)
    {
        var _options = options.Value ?? throw new ArgumentNullException(nameof(options)); 
        var baseUriBuilder = new UriBuilder("http", _options.hostname, _options.port, _options.basePath);
        
        _httpClient = httpClient;
        httpClient.BaseAddress = baseUriBuilder.Uri;
    }

}