using AR.AspNetCore.Logics.Consts;

namespace AR.AspNetCore.Logics.Helpers.Errors.Models;

public class LangInfo
{
    public string Latn { get; set; }

    public string Cyrl { get; set; }

    public string Ru { get; set; }

    public string En { get; set; }

    public string this[string lang]
    {
        get
        {
            return lang switch
            {
                LangConsts.Latn => Latn,
                LangConsts.Cyrl => Cyrl,
                LangConsts.Ru => Ru,
                LangConsts.En => En,
                _ => Latn
            };
        }
    }
}