namespace Domain.Company.ValueObject;

public class CompanyId : Common.ValueObject {
  private CompanyId(Guid companyId) {
    Value = companyId;
  }

  public Guid Value { get; }


  public static CompanyId Create(Guid companyId = new()) {
    return new CompanyId(companyId);
  }

  public static CompanyId Create(string companyId) {
    return new CompanyId(Guid.Parse(companyId));
  }

  protected override IEnumerable<object> GetEqualityComponents() {
    yield return Value;
  }
}