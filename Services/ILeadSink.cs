using Adega.Models;

namespace Adega.Services;

public interface ILeadSink
{
    Task StoreAsync(LandingLeadInput lead, HttpContext httpContext, CancellationToken ct = default);
}
