using Application.Common.Constants;

namespace Application.Common.Interfaces;

public interface ILanguageCodeProvider {
  LanguageCode GetLanguageCode();
}