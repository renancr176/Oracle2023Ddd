﻿using System.Reflection;

namespace Rte2023Ddd.Domain.Core.Extensions;

public static class EnumExtensions
{
    public static T? GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
    {
        var type = enumValue.GetType();
        var memInfo = type.GetMember(enumValue.ToString()).First();
        var attributes = memInfo.GetCustomAttributes<T>(false);
        return attributes.FirstOrDefault();
    }
}