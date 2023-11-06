using Rte2023Ddd.Domain.Core.Attributes;
using System.ComponentModel;

namespace Rte2023Ddd.Domain.TmsContext.Enums;

public enum PersonTypeEnum
{
    [EnumDbStringValueAttribute("")]
    [DisplayName("")]
    None,
    [EnumDbStringValueAttribute("J")]
    [DisplayName("FÍSICA")]
    Legal,
    [EnumDbStringValueAttribute("F")]
    [DisplayName("JURÍDICA")]
    Natural,
    [EnumDbStringValueAttribute("E")]
    [DisplayName("ESTRANGEIRO")]
    Foreign 
}