using Domain.Tenant.ValueObject;
using System.IdentityModel.Tokens.Jwt;
using Domain.User.ValueObject;

namespace Application.Common.Interfaces;

public interface IJwtGenerator {
    public JwtSecurityToken GenerateAccessToken(UserId userId, TenantId tenantId);
    public JwtSecurityToken GenerateRefreshToken(UserId userId, TenantId tenantId);
}