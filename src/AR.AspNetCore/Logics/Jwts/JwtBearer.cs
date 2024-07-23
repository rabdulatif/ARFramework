using System.IdentityModel.Tokens.Jwt;
using AR.AspNetCore.Logics.Helpers;
using Microsoft.IdentityModel.Tokens;
using NATS.Client.Internals;

namespace AR.AspNetCore.Logics.Jwts;

public class JwtBearer
{
    public static string GetToken(JwtBearerOption options)
    {
        var now = DateTime.UtcNow;
        var token = new JwtSecurityToken(
            AuthHelper.PARAM_ISS,
            AuthHelper.PARAM_AUD,
            notBefore: now,
            claims: options.Claims,
            expires: options.ExpireAt,
            signingCredentials: new SigningCredentials(
                AuthHelper.GetSecurityKey(options.SigningKey),
                SecurityAlgorithms.HmacSha256Signature
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static string GetGuidToken()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }
}