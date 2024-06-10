using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AR.AspNetCore.Logics.Helpers;

public class AuthHelper
{
    
#if DEBUG
    public const int EXPIRE_MINUTES = 60;
#else
        public const int EXPIRE_MINUTES = 3600;
#endif

#if DEBUG
    public const int EXPIRE_MINUTES_REFRESH = 90;
#else
        /// <summary>
        /// 
        /// </summary>
        public const int EXPIRE_MINUTES_REFRESH = 3630;
#endif

    public const string PARAM_ISS = "HostAuth";

    public const string PARAM_AUD = "param_sssxxxwwdf";

    public const string PARAM_SECRET_KEY = "Y2F0Y2hlciUyMsddtn258fglkjs=-HdvbfclMjAsb3ZlJTIwLm5ldA==";

    public const string ValidIssuer = "VoipValidIssure";

    public const string ValidAudence = "VoipValidAudence";

    public const string AuthenticationType = "AuthenticationType";

    public const string BearerSchema = "Bearer ";

    public static SymmetricSecurityKey GetSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PARAM_SECRET_KEY));
    }
}