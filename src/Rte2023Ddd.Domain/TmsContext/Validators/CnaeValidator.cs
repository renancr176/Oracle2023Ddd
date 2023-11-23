using FluentValidation;
using FluentValidation.Results;
using Rte2023Ddd.Domain.Core.DomainObjects;
using Rte2023Ddd.Domain.TmsContext.Entities;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Repositories;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Validators;

namespace Rte2023Ddd.Domain.TmsContext.Validators;

public class CnaeValidator :
    EntityStringIdValidator<Cnae>, 
    ICnaeValidator
{
    public static int _codeParentMaxLength = 8;

    public static int _descriptionMaxLength = 255;

    public static int _subClassMaxLength = 2;

    public static int _groupMaxLength = 1;

    public static int _divisionMaxLength = 2;

    public static int _idActivityMaxLength = 8;

    public static int _chapterNcmMaxLength = 5;

    public static int _sectionMaxLength = 1;

    public static int _classMaxLength = 2;

    #region Consts

    public const string CodeParentMaxLength = "O campo CodeParent do CNAE excedeu #LENGTH caracteres.";

    public const string DescriptionMaxLength = "O campo descrição do CNAE excedeu #LENGTH caracteres.";

    public const string SubClassMaxLength = "O campo SubClass do CNAE excedeu #LENGTH caracteres.";

    public const string GroupMaxLength = "O campo Group do CNAE excedeu #LENGTH caracteres.";

    public const string DivisionMaxLength = "O campo Division do CNAE excedeu #LENGTH caracteres.";

    public const string IdActivityMaxLength = "O campo IdActivity do CNAE excedeu #LENGTH caracteres.";

    public const string ChapterNcmMaxLength = "O campo ChapterNcm do CNAE excedeu #LENGTH caracteres.";

    public const string SectionMaxLength = "O campo Section do CNAE excedeu #LENGTH caracteres.";

    public const string ClassMaxLength = "O campo Class do CNAE excedeu #LENGTH caracteres.";

    #endregion

    public ValidationResult ValidationResult { get; private set; }

    private readonly ICnaeRepository _cnaeRepository;

    public CnaeValidator(ICnaeRepository cnaeRepository)
        : base(cnaeRepository, 1, 8)
    {
        _cnaeRepository = cnaeRepository;

        RuleFor(e => e.CodeParent)
            .MaximumLength(_codeParentMaxLength)
            .WithErrorCode(nameof(CodeParentMaxLength))
            .WithMessage(CodeParentMaxLength.Replace("#LENGTH", $"{_codeParentMaxLength}"));

        RuleFor(e => e.Description)
            .MaximumLength(_descriptionMaxLength)
            .WithErrorCode(nameof(DescriptionMaxLength))
            .WithMessage(DescriptionMaxLength.Replace("#LENGTH", $"{_descriptionMaxLength}"));

        RuleFor(e => e.SubClass)
            .MaximumLength(_subClassMaxLength)
            .WithErrorCode(nameof(SubClassMaxLength))
            .WithMessage(SubClassMaxLength.Replace("#LENGTH", $"{_subClassMaxLength}"));

        RuleFor(e => e.Group)
            .MaximumLength(_groupMaxLength)
            .WithErrorCode(nameof(GroupMaxLength))
            .WithMessage(GroupMaxLength.Replace("#LENGTH", $"{_groupMaxLength}"));

        RuleFor(e => e.Division)
            .MaximumLength(_divisionMaxLength)
            .WithErrorCode(nameof(DivisionMaxLength))
            .WithMessage(DivisionMaxLength.Replace("#LENGTH", $"{_divisionMaxLength}"));

        RuleFor(e => e.IdActivity)
            .MaximumLength(_idActivityMaxLength)
            .WithErrorCode(nameof(IdActivityMaxLength))
            .WithMessage(IdActivityMaxLength.Replace("#LENGTH", $"{_idActivityMaxLength}"));

        RuleFor(e => e.ChapterNcm)
            .MaximumLength(_chapterNcmMaxLength)
            .WithErrorCode(nameof(ChapterNcmMaxLength))
            .WithMessage(ChapterNcmMaxLength.Replace("#LENGTH", $"{_chapterNcmMaxLength}"));

        RuleFor(e => e.Section)
            .MaximumLength(_sectionMaxLength)
            .WithErrorCode(nameof(SectionMaxLength))
            .WithMessage(SectionMaxLength.Replace("#LENGTH", $"{_sectionMaxLength}"));

        RuleFor(e => e.Class)
            .MaximumLength(_classMaxLength)
            .WithErrorCode(nameof(ClassMaxLength))
            .WithMessage(ClassMaxLength.Replace("#LENGTH", $"{_classMaxLength}"));
    }

    public async Task<bool> IsValidAsync(Cnae entity)
    {
        ValidationResult = await ValidateAsync(entity);
        return ValidationResult.IsValid;
    }
}