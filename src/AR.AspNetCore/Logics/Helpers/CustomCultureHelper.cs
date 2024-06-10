using System.Globalization;
using SB.Common.Logics.SynonymProviders;

namespace AR.AspNetCore.Logics.Helpers;

public class CustomCultureHelper : CultureHelper
{
    public const string UzCyrlLanguageName = "uz-Cyrl-UZ";

    public static CultureInfo UzCyrlLanguage => CultureInfo.GetCultureInfo(UzCyrlLanguageName);
}