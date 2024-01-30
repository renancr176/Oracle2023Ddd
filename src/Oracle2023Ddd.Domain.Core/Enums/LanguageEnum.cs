using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Oracle2023Ddd.Domain.Core.Enums;

public enum LanguageEnum
{
    [Description("pt-BR")]
    [Display(Name = "Português")]
    Portugues,
    [Description("en-US")]
    [Display(Name = "English")]
    English
}