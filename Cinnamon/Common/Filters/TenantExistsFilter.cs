using Application.Common.Interfaces;
using Cinnamon.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cinnamon.Common.Filters;

public class TenantExistsFilter : IAsyncActionFilter {
    private readonly ITenantIdProvider _tenantIdProvider;

    public TenantExistsFilter(ITenantIdProvider tenantIdProvider) {
        _tenantIdProvider = tenantIdProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        var tenantId = _tenantIdProvider.GetTenantId();
        if (tenantId is null) throw new TenantIdRequiredException();
        await next();
    }
}