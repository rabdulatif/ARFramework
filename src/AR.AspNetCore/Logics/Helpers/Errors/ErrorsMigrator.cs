namespace AR.AspNetCore.Logics.Helpers.Errors;

public class ErrorsMigrator<T> where T : Enum
{
    public void Migrate()
    {
        var infos = ErrorsHelper<T>.GetLangInfos();
    }
}