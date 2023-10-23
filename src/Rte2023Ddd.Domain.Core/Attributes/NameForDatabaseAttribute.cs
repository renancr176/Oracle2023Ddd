﻿namespace Rte2023Ddd.Domain.Core.Attributes;

public class NameForDatabaseAttribute : Attribute
{
    public string Name { get; set; }

    public NameForDatabaseAttribute(string name)
    {
        Name = name;
    }
}