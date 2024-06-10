using System.Reflection;
using AR.AspNetCore.Logics.Helpers.Errors.Models;
using SB.Common.Logics.MemberDocumentations;

namespace AR.AspNetCore.Logics.Helpers.Errors;

public class ErrorsHelper<T> where T : Enum
{
    public static Dictionary<T, LangInfo> Infos { get; set; } = new();

    public static List<LangInfo> GetLangInfos()
    {
        var values = Enum.GetValues(typeof(T));
        var errors = values.Cast<T>().ToList();

        return errors.Select(GetLangInfo).ToList();
    }

    private static LangInfo GetLangInfo(T status)
    {
        if (Infos.TryGetValue(status, out var cashedInfo))
            return cashedInfo;

        var member = GetStatusMember(status);
        var info = new LangInfo();

        var memberInfo = MemberDocumentationManager.GetMemberDocumentation<CustomMemberInfo>(member);
        info.Latn = memberInfo.UzLatn;
        info.Cyrl = memberInfo.UzCyrl;
        info.Ru = memberInfo.Ru;

        Infos.TryAdd(status, info);
        return info;
    }

    private static MemberInfo GetStatusMember(T error)
    {
        var enumType = typeof(T);
        var memberInfos = enumType.GetMember(error.ToString());

        return memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
    }
}