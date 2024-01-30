﻿using System.Reflection;
using Oracle2023Ddd.Domain.Core.Attributes;

namespace Oracle2023Ddd.Domain.Core.Extensions;

public static class EnumExtensions
{
    public static T? GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
    {
        var type = enumValue.GetType();
        var memInfo = type.GetMember(enumValue.ToString()).First();
        var attributes = memInfo.GetCustomAttributes<T>(false);
        return attributes.FirstOrDefault();
    }

    public static string? ToDbValue(this Enum enumValue)
    {
        var attribute = GetAttributeOfType<EnumDbStringValueAttribute>(enumValue);
        return attribute?.DbValue;
    }
}