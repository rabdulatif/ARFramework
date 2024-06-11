using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace AR.AspNetCore;

public static class EfCoreExt
{
    public static WebApplicationBuilder AddDbContext<T>(this WebApplicationBuilder builder) where T : DbContext
    {
        builder.AddDbContext<T>();
        return builder;
    }
}