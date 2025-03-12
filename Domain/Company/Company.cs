using Domain.Common;
using Domain.Company.ValueObject;

namespace Domain.Company;

public class Company : AggregateRoot<CompanyId> {
  protected Company() : base() {}
  
  private Company(CompanyId id) : base(id) { }
  
  public string Name { get; private set; } = null!;
  
  public string Phone { get; private set; } = null!;
  
  public static Company Create(string name, string phone) {
    var company = new Company(CompanyId.Create()) {
      Name = name,
      Phone = phone
    };
    
    return company;
  }
}