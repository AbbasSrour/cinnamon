namespace Infrastructure.Services;

public class JwtTokenConfiguration {
  public string PublicKey { get; set; }
  public string PrivateKey { get; set; }
  public int Expiration { get; set; }
}

public class JwtSettings {
  public JwtTokenConfiguration AccessToken { get; set; }
  public JwtTokenConfiguration RefreshToken { get; set; }
}