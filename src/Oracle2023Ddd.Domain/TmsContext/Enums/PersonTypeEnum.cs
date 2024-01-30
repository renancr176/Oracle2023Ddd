using Oracle2023Ddd.Domain.Core.Attributes;

namespace Oracle2023Ddd.Domain.TmsContext.Enums;

public enum PersonTypeEnum
{
    [EnumDbStringValue("")]
    //[DisplayName("")]
    None,
    [EnumDbStringValue("J")]
    //[DisplayName("FÍSICA")]
    Legal,
    [EnumDbStringValue("F")]
    //[DisplayName("JURÍDICA")]
    Natural,
    [EnumDbStringValue("E")]
    //[DisplayName("ESTRANGEIRO")]
    Foreign 
}