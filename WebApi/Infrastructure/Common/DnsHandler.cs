namespace CleanArchitecture.Infrastructure.Common;

public class DnsHandler : HttpClientHandler
{
    public DnsHandler()
    {
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri is not null)
        {
            var builder = new UriBuilder(request.RequestUri)
            {
                Host = "host.docker.internal"
            };
            request.RequestUri = builder.Uri;
        }
        return base.SendAsync(request, cancellationToken);
    }
}