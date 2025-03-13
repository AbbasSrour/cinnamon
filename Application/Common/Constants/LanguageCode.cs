namespace Application.Common.Constants;

public class LanguageCode : IEquatable<LanguageCode> {
  private LanguageCode(
    string country,
    string language,
    string twoLetterCode,
    string threeLetterCode,
    List<string> lcidNumbers
  ) {
    Country = country;
    Language = language;
    TwoLetterCode = twoLetterCode;
    ThreeLetterCode = threeLetterCode;
    LcidNumbers = lcidNumbers;
  }

  public static LanguageCode EnUs => new(
    "United States",
    "English",
    "en-US",
    "en-USA",
    new List<string> { "1033", "4096" }
  );

  public static LanguageCode ArLb => new(
    "Lebanon",
    "Arabic",
    "ar-LB",
    "ar-LBN",
    new List<string> { "12289" }
  );


  public string Country { get; init; }
  public string Language { get; init; }
  public string TwoLetterCode { get; init; }
  public string ThreeLetterCode { get; init; }
  public List<string> LcidNumbers { get; init; }

  public bool Equals(LanguageCode? other) {
    if (ReferenceEquals(null, other)) return false;

    if (ReferenceEquals(this, other)) return true;

    return TwoLetterCode == other.TwoLetterCode;
  }


  public override string ToString() {
    return TwoLetterCode;
  }

  public override bool Equals(object? obj) {
    if (obj is null || obj.GetType() != GetType()) return false;

    return Equals((LanguageCode)obj);
  }

  public override int GetHashCode() {
    return TwoLetterCode.GetHashCode();
  }

  public static bool operator ==(LanguageCode left, LanguageCode right) {
    return Equals(left, right);
  }

  public static bool operator !=(LanguageCode left, LanguageCode right) {
    return !Equals(left, right);
  }
}