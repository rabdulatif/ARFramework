using SB.Common.Logics.MemberDocumentations.Attributes;

namespace AR.AspNetCore.Logics.Helpers.Errors.Models;

public class CustomMemberInfo
{
    [MemberDocumentationProperty("uzLatn")]
    public string UzLatn { get; set; }

    [MemberDocumentationProperty("uzCyrl")]
    public string UzCyrl { get; set; }

    [MemberDocumentationProperty("ru")]
    public string Ru { get; set; }

    [MemberDocumentationProperty("en")]
    public string En { get; set; }
}