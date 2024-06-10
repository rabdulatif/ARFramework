using Microsoft.AspNetCore.Http;

namespace AR.AspNetCore.Logics.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor Accessor;

    public static HttpContext Current => Accessor?.HttpContext;
}