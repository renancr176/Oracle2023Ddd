using FluentValidation;
using FluentValidation.Results;
using Rte2023Ddd.Domain.Core.Extensions;
using Rte2023Ddd.Domain.TmsContext.Entities;
using Rte2023Ddd.Domain.TmsContext.Enums;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Repositories;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Validators;

namespace Rte2023Ddd.Domain.TmsContext.Validators;

public class PersonValidator : AbstractValidator<Person>, IPersonValidator
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

    #region System control params

    public const string CreatorProgramIsRequired = "O nome do objeto de criação é obrigatório.";
    public const string CreatorProgramMinLength = "O nome do objeto de criação deve ter ao menos #LENGHT caracater(es).";
    public const string CreatorProgramMaxLength = "O nome do objeto de criação excedeu #LENGTH caracteres.";

    public const string CreatorUserMinVal = "O Id do usuário de criação deve ser maior que #VAL.";
    //public const string CreatorUserNotExists = "O usuário de criação inexistente.";

    public const string UpdateProgramIsRequired = "O nome do objeto de alteração é obrigatório.";
    public const string UpdateProgramMinLength = "O nome do objeto de alteração deve ter ao menos #LENGHT caracater(es).";
    public const string UpdateProgramMaxLength = "O nome do objeto de alteração excedeu #LENGTH caracteres.";

    public const string UpdateUserMinVal = "O Id do usuário de alteração deve ser maior que #VAL.";
    //public const string UpdateUserNotExists = "O usuário de alteração inexistente.";

    public const string UserBddIsRequired = "O nome do sistema de criação é obrigatório.";
    public const string UserBddMinLength = "O nome do sistema de criação deve pussuir ao menos #LENGTH caracter(es).";
    public const string UserBddMaxLength = "O nome do sistema de criação excedeu #LENGTH caracteres.";

    public const string SysRevisaMinVal = "O código do sistema de criação deve maior que #VAL.";

    #endregion

    #endregion

    public ValidationResult ValidationResult { get; private set; }

    private readonly IPersonRepository _personRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IAddressValidator _addressValidator;

    public PersonValidator(IPersonRepository personRepository,
        IAddressRepository addressRepository,
        IAddressValidator addressValidator)
    {
        _personRepository = personRepository;
        _addressRepository = addressRepository;
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

        RuleFor(e => e.StadualIdRegistration);

        RuleFor(e => e.RegionalIdRegistration);

        RuleFor(e => e.Description);

        RuleFor(e => e.ReductedDescription);

        RuleFor(e => e.FictitiousName);

        RuleFor(e => e.Cnae);

        RuleFor(e => e.CnaeDescription);

        RuleFor(e => e.CnaeDescription);

        #region System control params

        RuleFor(e => e.CreatorProgram)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(CreatorProgramIsRequired))
            .WithMessage(CreatorProgramIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(CreatorProgramIsRequired))
            .WithMessage(CreatorProgramIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(CreatorProgramMinLength))
            .WithMessage(CreatorProgramMinLength.Replace("#LENGTH", "1"))
            .MaximumLength(35)
            .WithErrorCode(nameof(CreatorProgramMaxLength))
            .WithMessage(CreatorProgramMaxLength.Replace("#LENGTH", "35"));

        RuleFor(e => e.CreatorUser)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .WithErrorCode(nameof(CreatorUserMinVal))
            .WithMessage(CreatorUserMinVal.Replace("#VAL", ""));
        //.MustAsync(UserExistsAsync)
        //.WithErrorCode(nameof(CreatorUserNotExists))
        //.WithMessage(CreatorUserNotExists);

        RuleFor(e => e.UpdateProgram)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(UpdateProgramIsRequired))
            .WithMessage(UpdateProgramIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(UpdateProgramIsRequired))
            .WithMessage(UpdateProgramIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(UpdateProgramMinLength))
            .WithMessage(UpdateProgramMinLength.Replace("#LENGTH", "1"))
            .MaximumLength(35)
            .WithErrorCode(nameof(UpdateProgramMaxLength))
            .WithMessage(UpdateProgramMaxLength.Replace("#LENGTH", "35"));

        RuleFor(e => e.UpdateUser)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .WithErrorCode(nameof(UpdateUserMinVal))
            .WithMessage(UpdateUserMinVal.Replace("#VAL", ""));
        //.MustAsync(UserExistsAsync)
        //.WithErrorCode(nameof(UpdateUserNotExists))
        //.WithMessage(UpdateUserNotExists);

        RuleFor(e => e.UserBdd)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(UserBddIsRequired))
            .WithMessage(UserBddIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(UserBddIsRequired))
            .WithMessage(UserBddIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(UserBddMinLength))
            .WithMessage(UserBddMinLength)
            .MaximumLength(35)
            .WithErrorCode(nameof(UserBddMaxLength))
            .WithMessage(UserBddMaxLength);

        RuleFor(e => e.SysRevisa)
            .GreaterThan(0)
            .WithErrorCode(nameof(SysRevisaMinVal))
            .WithMessage(SysRevisaMinVal.Replace("#VAL", "0"));

        #endregion
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
