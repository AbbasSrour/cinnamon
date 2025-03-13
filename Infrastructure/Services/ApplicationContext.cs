using Application.Common.Constants;
using Application.Common.Interfaces;
using Domain.Tenant.ValueObject;

namespace Infrastructure.Services;

public class ApplicationContext : IApplicationContext {
  private readonly ILanguageCodeProvider _languageCodeProvider;
  private readonly ITenantIdProvider _tenantIdProvider;

  public ApplicationContext(ITenantIdProvider tenantIdProvider, ILanguageCodeProvider languageCodeProvider) {
    _tenantIdProvider = tenantIdProvider;
    _languageCodeProvider = languageCodeProvider;
  }

  public TenantId? TenantId => _tenantIdProvider.GetTenantId();
  public LanguageCode LanguageCode => _languageCodeProvider.GetLanguageCode();
}