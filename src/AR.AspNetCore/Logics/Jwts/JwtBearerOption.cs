using System.Security.Claims;

namespace AR.AspNetCore.Logics.Jwts;

public class JwtBearerOption
{
    public string SigningKey { get; set; }

    public DateTime? ExpireAt { get; set; }

    public List<Claim> Claims { get; set; } = new();
}