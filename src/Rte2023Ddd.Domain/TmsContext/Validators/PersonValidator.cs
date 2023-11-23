using FluentValidation;
using FluentValidation.Results;
using Rte2023Ddd.Domain.Core.DomainObjects;
using Rte2023Ddd.Domain.Core.Extensions;
using Rte2023Ddd.Domain.TmsContext.Entities;
using Rte2023Ddd.Domain.TmsContext.Enums;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Repositories;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Validators;

namespace Rte2023Ddd.Domain.TmsContext.Validators;

public class PersonValidator : 
    EntityValidator<Person>, 
    IPersonValidator
{
    #region Consts

    public const string TypePersonIsInvalid = "O tipo de pessoa informado é inválido.";

    public const string TypePersonDbIsRequired = "O tipo de pessoa é obrigatório.";
    public const string TypePersonDbMinVal = "O tipo de pessoa valor do DB deve possuir ao menos #LENGTH caracter(es).";
    public const string TypePersonDbMaxVal = "O tipo de pessoa valor do DB excedeu #LENGTH caracter(es).";
    
    public const string TaxIdRegistrationIsRequired = "O TaxIdRegistration é obrigatório.";
    public const string TaxIdRegistrationMinLength = "O TaxIdRegistration deve possuir ao menos #LENGTH caracter(es).";
    public const string TaxIdRegistrationMaxLength = "O TaxIdRegistration excedeu #LENGTH caracteres.";
    public const string TaxIdRegistrationIsInvaid = "O TaxIdRegistration excedeu #LENGTH caracteres.";
    public const string TaxIdRegistrationAlreadyExists = "Já existe um cadastro com o mesmo TaxIdRegistration informado.";
    
    public const string StadualIdRegistrationMaxLength = "O registro estadual excedeu #LENGTH caracteres.";
    
    public const string RegionalIdRegistrationMaxLength = "O registro regional excedeu #LENGTH caracteres.";
    
    public const string DescriptionIsRequired = "O nome é obrigatório.";
    public const string DescriptionMinLength = "O nome deve conter ao menos #LENGTH caracter(es).";
    public const string DescriptionMaxLength = "O nome excedeu #LENGTH caracteres.";

    public const string ReductedDescriptionMaxLength = "O nome reduzido excedeu #LENGTH caracteres.";
    
    public const string FictitiousNameMaxLength = "O nome fantasia excedeu #LENGTH caracteres.";

    public const string CnaeMinLength = "O CNAE deve possuir ao menos #LENGTH caracter(es).";
    public const string CnaeMaxLength = "O CNAE excedeu #LENGTH caracteres.";
    public const string CnaeNotExists = "O CNAE informado não existe.";

    public const string CnaeDescriptionIsRequired = "A descrição do CNAE é obrigatória.";
    public const string CnaeDescriptionMinLength = "A descrição do CNAE deve conter ao menos #LENGTH caracter(es).";
    public const string CnaeDescriptionMaxLength = "A descrição do CNAE excedeu #LENGTH caracteres.";
    public const string CnaeDescriptionNotAllowed = "A descrição do CNAE só pode ser informada se o número do CNAE for informado.";

    #endregion

    public ValidationResult ValidationResult { get; private set; }

    private readonly IPersonRepository _personRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly ICnaeRepository _cnaeRepository;
    private readonly IAddressValidator _addressValidator;

    public PersonValidator(IPersonRepository personRepository,
        IAddressRepository addressRepository,
        ICnaeRepository cnaeRepository,
        IAddressValidator addressValidator)
    {
        _personRepository = personRepository;
        _addressRepository = addressRepository;
        _cnaeRepository = cnaeRepository;
        _addressValidator = addressValidator;

        RuleForEach(e => e.Addresses)
            .Cascade(CascadeMode.Stop)
            .SetValidator(_addressValidator);

        RuleFor(e => e.TypePerson)
            .IsInEnum()
            .WithErrorCode(nameof(TypePersonIsInvalid))
            .WithMessage(TypePersonIsInvalid);

        RuleFor(e => e.TypePersonDb)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(TypePersonDbIsRequired))
            .WithMessage(TypePersonDbIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(TypePersonDbIsRequired))
            .WithMessage(TypePersonDbIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(TypePersonDbMinVal))
            .WithMessage(TypePersonDbMinVal)
            .MinimumLength(5)
            .WithErrorCode(nameof(TypePersonDbMaxVal))
            .WithMessage(TypePersonDbMaxVal);

        RuleFor(e => e.TaxIdRegistration)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(TaxIdRegistrationIsRequired))
            .WithMessage(e => ReplaceTaxIdRegistrationOnErroMessage(e, TaxIdRegistrationIsRequired))
            .NotEmpty()
            .WithErrorCode(nameof(TaxIdRegistrationIsRequired))
            .WithMessage(e => ReplaceTaxIdRegistrationOnErroMessage(e, TaxIdRegistrationIsRequired))
            .MinimumLength(1)
            .WithErrorCode(nameof(TaxIdRegistrationMinLength))
            .WithMessage(e => ReplaceTaxIdRegistrationOnErroMessage(e, TaxIdRegistrationMinLength).Replace("#LENGTH", "1"))
            .MaximumLength(15)
            .WithErrorCode(nameof(TaxIdRegistrationMaxLength))
            .WithMessage(e => ReplaceTaxIdRegistrationOnErroMessage(e, TaxIdRegistrationMaxLength).Replace("#LENGTH", "15"))
            .Must(ValidTaxIdRegistration)
            .WithErrorCode(nameof(TaxIdRegistrationIsInvaid))
            .WithMessage(e => ReplaceTaxIdRegistrationOnErroMessage(e, TaxIdRegistrationIsInvaid))
            .MustAsync(UniqueTaxIdRegistrationAsync)
            .WithErrorCode(nameof(TaxIdRegistrationAlreadyExists))
            .WithMessage(e => ReplaceTaxIdRegistrationOnErroMessage(e, TaxIdRegistrationAlreadyExists));

        RuleFor(e => e.StadualIdRegistration)
            .MaximumLength(15)
            .WithErrorCode(nameof(StadualIdRegistrationMaxLength))
            .WithMessage(StadualIdRegistrationMaxLength.Replace("#LENGTH", "15"));

        RuleFor(e => e.RegionalIdRegistration)
            .MaximumLength(35)
            .WithErrorCode(nameof(RegionalIdRegistrationMaxLength))
            .WithMessage(RegionalIdRegistrationMaxLength.Replace("#LENGTH", "35")); ;

        RuleFor(e => e.Description)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(DescriptionIsRequired))
            .WithMessage(DescriptionIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(DescriptionIsRequired))
            .WithMessage(DescriptionIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(DescriptionMinLength))
            .WithMessage(DescriptionMinLength.Replace("#LENGTH", "1"))
            .MaximumLength(65)
            .WithErrorCode(nameof(DescriptionMaxLength))
            .WithMessage(DescriptionMaxLength.Replace("#LENGTH", "65"));

        RuleFor(e => e.ReductedDescription)
            .MaximumLength(35)
            .WithErrorCode(nameof(ReductedDescriptionMaxLength))
            .WithMessage(ReductedDescriptionMaxLength.Replace("#LENGTH", "35"));

        RuleFor(e => e.FictitiousName)
            .MaximumLength(65)
            .WithErrorCode(nameof(FictitiousNameMaxLength))
            .WithMessage(FictitiousNameMaxLength.Replace("#LENGTH", "65"));


        When(e => !string.IsNullOrEmpty(e.IdCnae.Trim()), () =>
        {
            RuleFor(e => e.IdCnae)
                .MinimumLength(8)
                .WithErrorCode(nameof(CnaeMinLength))
                .WithMessage(CnaeMinLength.Replace("#LENGTH", "8"))
                .MaximumLength(8)
                .WithErrorCode(nameof(CnaeMaxLength))
                .WithMessage(CnaeMaxLength.Replace("#LENGTH", "8"))
                .MustAsync(CnaeExistsAsync)
                .WithErrorCode(nameof(CnaeNotExists))
                .WithMessage(CnaeNotExists);

            RuleFor(e => e.CnaeDescription)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithErrorCode(nameof(CnaeDescriptionIsRequired))
                .WithMessage(CnaeDescriptionIsRequired)
                .NotEmpty()
                .WithErrorCode(nameof(CnaeDescriptionIsRequired))
                .WithMessage(CnaeDescriptionIsRequired)
                .MaximumLength(1)
                .WithErrorCode(nameof(CnaeDescriptionMinLength))
                .WithMessage(CnaeDescriptionMinLength.Replace("#LENGTH", "1"))
                .MaximumLength(255)
                .WithErrorCode(nameof(CnaeDescriptionMaxLength))
                .WithMessage(CnaeDescriptionMaxLength.Replace("#LENGTH", "255"));

        }).Otherwise(() =>
        {
            RuleFor(e => e.CnaeDescription)
                .Null()
                .WithErrorCode(nameof(CnaeDescriptionNotAllowed))
                .WithMessage(CnaeDescriptionNotAllowed);
        });
    }

    private async Task<bool> CnaeExistsAsync(string idCnae, CancellationToken arg2)
    {
        return await _cnaeRepository.AnyAsync(e => e.Id == idCnae);
    }

    private string ReplaceTaxIdRegistrationOnErroMessage(Person entity, string message)
    {
        switch (entity.TypePerson)
        {
            case PersonTypeEnum.Natural:
                return message.Replace("TaxIdRegistration", "CPF");
            case PersonTypeEnum.Legal:
                return message.Replace("TaxIdRegistration", "CNPJ");
            default:
                return message.Replace("TaxIdRegistration", "documento de identificação");
        }
    }

    private bool ValidTaxIdRegistration(Person entity, string taxIdRegistration)
    {
        switch (entity.TypePerson)
        {
            case PersonTypeEnum.Natural:
                return taxIdRegistration.IsCpf();
            case PersonTypeEnum.Legal:
                return taxIdRegistration.IsCnpj();
            default:
                return true;
        }
    }

    private async Task<bool> UniqueTaxIdRegistrationAsync(Person entity, string taxIdRegistration, CancellationToken token)
    {
        return !await _personRepository.AnyAsync(e => e.Id != entity.Id && e.TaxIdRegistration == taxIdRegistration);
    }

    public async Task<bool> IsValidAsync(Person entity)
    {
        ValidationResult = await ValidateAsync(entity);
        return ValidationResult.IsValid;
    }
}
