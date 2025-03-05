using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Common.Interfaces;
using Domain.Tenant.ValueObject;
using Domain.User.ValueObject;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class JwtGenerator : IJwtGenerator {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IOptions<JwtSettings> _jwtSettings;

    public JwtGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings) {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings;
    }

    public JwtSecurityToken GenerateAccessToken(UserId userId, TenantId tenantId) {
        var claims = new List<Claim> {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sid, userId.Value.ToString()),
            new("tid", tenantId.ToString()!)
        };
        var token = new JwtSecurityToken(
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddDays(_jwtSettings.Value.AccessToken.Expiration)
        );

        return token;
    }

    public JwtSecurityToken GenerateRefreshToken(UserId userId, TenantId tenantId) {
        var claims = new List<Claim> {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sid, userId.Value.ToString()),
            new("tid", tenantId.ToString()!)
        };
        var token = new JwtSecurityToken(
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddDays(_jwtSettings.Value.RefreshToken.Expiration)
        );

        return token;
    }
}