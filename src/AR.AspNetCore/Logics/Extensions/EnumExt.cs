using AR.AspNetCore.Logics.Consts;
using AR.AspNetCore.Logics.Helpers.Errors;

namespace AR.AspNetCore;

public static class EnumExt
{
    public static string GetString<TEnum>(this TEnum error) where TEnum : Enum
    {
        ErrorsHelper<TEnum>.Infos.TryGetValue(error, out var result);
        return LangConsts.CurrentLanguage switch
        {
            LangConsts.Latn => result?.Latn,
            LangConsts.Cyrl => result?.Cyrl,
            LangConsts.Ru => result?.Ru,
            LangConsts.En => result?.En
        };
    }
}