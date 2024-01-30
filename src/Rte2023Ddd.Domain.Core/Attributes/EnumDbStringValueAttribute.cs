namespace Oracle2023Ddd.Domain.Core.Attributes;

public class EnumDbStringValueAttribute : Attribute
{
    public string? DbValue { get; set; }

    public EnumDbStringValueAttribute(string? dbValue)
    {
        DbValue = dbValue;
    }
}
