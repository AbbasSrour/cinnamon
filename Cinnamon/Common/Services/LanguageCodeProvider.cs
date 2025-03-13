using Application.Common.Constants;
using Application.Common.Interfaces;

namespace Cinnamon.Common.Services;

public class LanguageCodeProvider : ILanguageCodeProvider {
  private readonly IHttpContextAccessor _httpContextAccessor;

  public LanguageCodeProvider(IHttpContextAccessor httpContextAccessor) {
    _httpContextAccessor = httpContextAccessor;
  }

  public LanguageCode GetLanguageCode() {
    var code = _httpContextAccessor.HttpContext?.Request.Headers["X-Language-Code"];

    return code.ToString() switch {
      "en-US" => LanguageCode.EnUs,
      "ar-LB" => LanguageCode.ArLb,
      _ => LanguageCode.EnUs
    };
  }
}