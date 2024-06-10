namespace AR.AspNetCore.Logics.Consts;

public class LangConsts
{
    public const string Latn = "latn";

    public const string Cyrl = "cyrl";

    public const string Ru = "ru";

    public const string En = "en";

    private static string _key { get; set; }

    public static string CurrentLanguage
    {
        get => string.IsNullOrEmpty(_key) ? Latn : _key;
        set => _key = value;
    }
}