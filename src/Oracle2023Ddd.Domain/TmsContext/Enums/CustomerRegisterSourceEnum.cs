using Oracle2023Ddd.Domain.Core.Attributes;

namespace Oracle2023Ddd.Domain.TmsContext.Enums;

public enum CustomerRegisterSourceEnum
{
    [EnumDbStringValue("0")]
    TMS,
    [EnumDbStringValue("1")]
    Site
}