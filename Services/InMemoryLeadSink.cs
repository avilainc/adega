using Adega.Models;

namespace Adega.Services;

public sealed class InMemoryLeadSink : ILeadSink
{
    private readonly List<(DateTimeOffset At, LandingLeadInput Lead, string Ip)> _items = new();

    public Task StoreAsync(LandingLeadInput lead, HttpContext httpContext, CancellationToken ct = default)
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        // Se honeypot preenchido, descarta silenciosamente
        if (!string.IsNullOrWhiteSpace(lead.Website))
            return Task.CompletedTask;

        _items.Add((DateTimeOffset.UtcNow, lead, ip));
        return Task.CompletedTask;
    }
}
