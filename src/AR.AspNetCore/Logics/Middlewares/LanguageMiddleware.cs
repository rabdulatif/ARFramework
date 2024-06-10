using System.Globalization;
using AR.AspNetCore.Logics.Consts;
using AR.AspNetCore.Logics.Helpers;
using Microsoft.AspNetCore.Http;
using SB.Common.Logics.SynonymProviders;

namespace AR.AspNetCore.Logics.Middlewares;

public class LanguageMiddleware
{
    private readonly Dictionary<string, string> _languages;

    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;

        _languages = new()
        {
            { LangConsts.Latn, CustomCultureHelper.UzLanguageName },
            { LangConsts.Cyrl, CustomCultureHelper.UzCyrlLanguageName },
            { LangConsts.Ru, CustomCultureHelper.RuLanguageName },
            { LangConsts.En, CustomCultureHelper.EnLanguageName }
        };
    }

    public async Task InvokeAsync(HttpContext context)
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(CultureHelper.RuLanguageName);
        CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(CultureHelper.RuLanguageName);

        var language = context.Request.Headers["Language"];
        if (!string.IsNullOrEmpty(language) && _languages.TryGetValue(language, out var cultureName))
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);
            LangConsts.CurrentLanguage = language;
        }

        await _next(context);
    }
}