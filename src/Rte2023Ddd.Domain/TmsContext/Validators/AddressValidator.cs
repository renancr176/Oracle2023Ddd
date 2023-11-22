using FluentValidation;
using FluentValidation.Results;
using Rte2023Ddd.Domain.Core.DomainObjects;
using Rte2023Ddd.Domain.TmsContext.Entities;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Repositories;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Validators;
using System.Globalization;

namespace Rte2023Ddd.Domain.TmsContext.Validators;

public class AddressValidator :
    EntityValidator<Address>,
    IAddressValidator
{
    public IEnumerable<string> Types = new[]
    {
        "FISCO",
        "COBRC",
        "ENTRG",
        "REDES",
        "PONTO"
    };

    public IEnumerable<string> Origins = new[]
    {
        "ESTRA",
        "CPC",
        "LOG",
        "GUS",
        "LOC",
        "UOP"
    };

    #region Consts

    public const string TypeIsRequired = "O campo tipo do endereço é obrigatório.";
    public const string TypeMaxLength = "O valor do tipo do endereço excedeu #LENGTH caracteres.";
    public const string TypeInvalidValue = "O valor do tipo do endereço é invalido, deve ser um dos seguinte valores (#VALUES).";
    
    public const string BeginningDateIsRequired = "A data de início do endereço é obrigatória.";
    public const string BeginningDateMinVal = "O valor da data de início do endereço deve ser maior que #VAL.";

    public const string EndingDateMinVal = "O valor da data de termino do endereço deve ser maior que #VAL.";

    public const string CepIsRequired = "O CEP do endereço é obrigatório.";
    public const string CepMinMaxLenght = "O CEP do endereço deve conter #LENGTH digitos.";

    public const string TypeAddressMaxLenght = "O tipo de logradroudo do endereço excedeu #LENGTH caracteres.";

    public const string NumberMaxLenght = "O número do endereço excedeu #LENGTH digitos.";

    public const string SupplementMaxLenght = "O complemento do endereço excedeu #LENGTH caracteres.";
    
    public const string DistrictMaxLenght = "O bairro do endereço excedeu #LENGTH caracteres.";

    public const string CityMaxLenght = "A cidade do endereço excedeu #LENGTH caracteres.";

    public const string IbgeCityMaxLenght = "O IBGE cidade do endereço excedeu #LENGTH caracteres.";    
    
    public const string UnitFederationCodeIsRequired = "A sigla do estado do endereço é obrigatório.";
    public const string UnitFederationCodeMinMaxLenght = "A sigla do estado do endereço deve possuir #LENGTH caracteres.";

    public const string StateMaxLenght = "O estado do endereço excedeu #LENGTH caracteres.";

    public const string IbgeUfMinVal = "O código IBGE do estado do endereço deve ser maior que #VAL.";
    
    public const string CountryMaxLenght = "O país do endereço excedeu #LENGTH caracteres.";

    public const string IbgeCountryMinVal = "O código IBGE do país do endereço deve ser maior que #VAL.";

    public const string IdPersonNotExists = "A pessoa informada no endereço Id #VAL não existe.";

    public const string OriginIsRequired = "A origem do endereço é obrigatória.";
    public const string OriginMinLength = "A origem do endereço deve conter ao menos #LENGTH caractere(s).";
    public const string OriginMaxLength = "A origem do enderelo excedeu #LENGTH caracteres.";
    public const string OriginInvalidValue = "O valor da origem do endereço é invalida, deve ser um dos seguinte valores (#VALUES).";
    
    public const string CountryCodeIsRequired = "A sigla do país do endereço é obrigatório.";
    public const string CountryCodeMinLength = "A sigla do país do endereço deve conter ao menos #LENGTH caracter(s).";
    public const string CountryCodeMaxLength = "A sigla do país do endereço excedeu #LENGTH caracteres.";

    public const string CityIdMinVal = "O Id da cidade informada do endereço deve ser maior que #VAL.";
    
    public const string ParentIdMinVal = "O Id do endereço principal deve ser maior que #VAL.";
    public const string ParentIdNotExists = "O endereço principal não existe.";
    
    public const string RedispatchDescriptionMaxLenght = "A descição do redespacho do endereço excedeu #LENGTH caracteres.";
    
    public const string WindowDeliveryBeginMinVal = "A data de início da janela de entrega do endereço deve ser maior que #VAL.";

    public const string WindowDeliveryFinalMinVal = "A data final da janela de entrega do endereço deve ser maior que a data de início.";
    public const string WindowDeliveryFinalShouldBeNull = "A data final da janela de entrega do endereço não pode ter valor pois a data de início não foi definida.";

    public const string RestrictWindowDeliveryBeginMinVal = "A data de início de restrição da janela de entrega do endereço deve ser maior que #VAL.";

    public const string RestrictWindowDeliveryFinalMinVal = "A data final de restrição da janela de entrega do endereço deve ser maior que a data de início.";
    public const string RestrictWindowDeliveryFinalShouldBeNull = "A data final de restrição da janela de entrega do endereço não pode ter valor pois a data de início não foi definida.";
    
    public const string ConflictBetweenWindowDelivery = "Existe conflito entre as datas de restrição e funcionamento das janelas de entrega do endereço.";

    #endregion

    public ValidationResult ValidationResult { get; private set; }

    private readonly IAddressRepository _addressRepository;
    private readonly IPersonRepository _personRepository;

    public AddressValidator(IAddressRepository addressRepository,
        IPersonRepository personRepository)
    {
        _addressRepository = addressRepository;
        _personRepository = personRepository;

        RuleFor(e => e.Type)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(TypeIsRequired))
            .WithMessage(TypeIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(TypeIsRequired))
            .WithMessage(TypeIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(TypeIsRequired))
            .WithMessage(TypeIsRequired)
            .MaximumLength(5)
            .WithErrorCode(nameof(TypeMaxLength))
            .WithMessage(TypeMaxLength.Replace("#LENGTH", "5"))
            .Must(ValidType)
            .WithErrorCode(nameof(TypeInvalidValue))
            .WithMessage(TypeInvalidValue.Replace("#VALUES", string.Join(" ou ", Types)));

        RuleFor(e => e.BeginningDate)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(BeginningDateIsRequired))
            .WithMessage(BeginningDateIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(BeginningDateIsRequired))
            .WithMessage(BeginningDateIsRequired)
            .GreaterThan(DateTime.MinValue)
            .WithErrorCode(nameof(BeginningDateMinVal))
            .WithMessage(BeginningDateMinVal.Replace("#VAL", DateTime.MinValue.ToString("G", new CultureInfo("pt-BR"))));

        When(e => e.EndingDate.HasValue, () =>
        {
            RuleFor(e => e.EndingDate)
                .GreaterThan(e => e.BeginningDate)
                .WithErrorCode(nameof(EndingDateMinVal))
                .WithMessage(e => EndingDateMinVal.Replace("#VAL", e.BeginningDate.ToString("G", new CultureInfo("pt-BR"))));
        });

        RuleFor(e => e.Cep)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(CepIsRequired))
            .WithMessage(CepIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(CepIsRequired))
            .WithMessage(CepIsRequired)
            .MinimumLength(8)
            .WithErrorCode(nameof(CepMinMaxLenght))
            .WithMessage(CepMinMaxLenght.Replace("#LENGTH", "8"))
            .MaximumLength(8)
            .WithErrorCode(nameof(CepMinMaxLenght))
            .WithMessage(CepMinMaxLenght.Replace("#LENGTH", "8"));

        RuleFor(e => e.TypeAddress)
            .MaximumLength(35)
            .WithErrorCode(nameof(TypeAddressMaxLenght))
            .WithMessage(TypeAddressMaxLenght.Replace("#LENGTH", "35"));

        RuleFor(e => e.Number)
            .MaximumLength(35)
            .WithErrorCode(nameof(NumberMaxLenght))
            .WithMessage(NumberMaxLenght.Replace("#LENGTH", "35"));

        RuleFor(e => e.Supplement)
            .MaximumLength(35)
            .WithErrorCode(nameof(SupplementMaxLenght))
            .WithMessage(SupplementMaxLenght.Replace("#LENGTH", "35"));

        RuleFor(e => e.District)
            .MaximumLength(35)
            .WithErrorCode(nameof(DistrictMaxLenght))
            .WithMessage(DistrictMaxLenght.Replace("#LENGTH", "35"));

        RuleFor(e => e.City)
            .MaximumLength(65)
            .WithErrorCode(nameof(CityMaxLenght))
            .WithMessage(CityMaxLenght.Replace("#LENGTH", "65"));

        RuleFor(e => e.IbgeCity)
            .MaximumLength(35)
            .WithErrorCode(nameof(IbgeCityMaxLenght))
            .WithMessage(IbgeCityMaxLenght.Replace("#LENGTH", "35"));

        RuleFor(e => e.UnitFederationCode)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(UnitFederationCodeIsRequired))
            .WithMessage(UnitFederationCodeIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(UnitFederationCodeIsRequired))
            .WithMessage(UnitFederationCodeIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(UnitFederationCodeMinMaxLenght))
            .WithMessage(UnitFederationCodeMinMaxLenght.Replace("#LENGTH", "2"))
            .MaximumLength(2)
            .WithErrorCode(nameof(UnitFederationCodeMinMaxLenght))
            .WithMessage(UnitFederationCodeMinMaxLenght.Replace("#LENGTH", "2"));

        RuleFor(e => e.State)
            .MaximumLength(35)
            .WithErrorCode(nameof(StateMaxLenght))
            .WithMessage(StateMaxLenght.Replace("#LENGTH", "35"));

        When(e => e.IbgeUf.HasValue, () =>
        {
            RuleFor(e => e.IbgeUf)
                .GreaterThan(0)
                .WithErrorCode(nameof(IbgeUfMinVal))
                .WithMessage(IbgeUfMinVal.Replace("#VAL", "0"));
        });

        RuleFor(e => e.Country)
            .MaximumLength(35)
            .WithErrorCode(nameof(CountryMaxLenght))
            .WithMessage(CountryMaxLenght.Replace("#LENGTH", "35"));

        When(e => e.IbgeCountry != null, () =>
        {
            RuleFor(e => e.IbgeCountry)
                .GreaterThan(0)
                .WithErrorCode(nameof(IbgeCountryMinVal))
                .WithMessage(IbgeCountryMinVal.Replace("#VAL", "0"));
        });

        When(e => e.IdPerson.HasValue, () =>
        {
            RuleFor(e => e.IdPerson)
                .MustAsync(PersonMustExistsAsync)
                .WithErrorCode(nameof(IdPersonNotExists))
                .WithMessage(e => IdPersonNotExists.Replace("#VAL", e.IdPerson.ToString()));
        });

        RuleFor(e => e.Origin)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(OriginIsRequired))
            .WithMessage(OriginIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(OriginIsRequired))
            .WithMessage(OriginIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(OriginMinLength))
            .WithMessage(OriginMinLength.Replace("#LENGTH", "1"))
            .MaximumLength(5)
            .WithErrorCode(nameof(OriginMaxLength))
            .WithMessage(OriginMaxLength.Replace("#LENGTH", "5"))
            .Must(ValidOrigin)
            .WithErrorCode(nameof(OriginInvalidValue))
            .WithMessage(OriginInvalidValue.Replace("#VALUES", string.Join(" ou ", Origins)));

        RuleFor(e => e.CountryCode)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(CountryCodeIsRequired))
            .WithMessage(CountryCodeIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(CountryCodeIsRequired))
            .WithMessage(CountryCodeIsRequired)
            .MinimumLength(1)
            .WithErrorCode(nameof(CountryCodeMinLength))
            .WithMessage(CountryCodeMinLength.Replace("#LENGTH", "1"))
            .MaximumLength(2)
            .WithErrorCode(nameof(CountryCodeMaxLength))
            .WithMessage(CountryCodeMaxLength.Replace("#LENGTH", "2"));

        RuleFor(e => e.CityId)
            .GreaterThan(0)
            .WithErrorCode(nameof(CityIdMinVal))
            .WithMessage(CityIdMinVal.Replace("#VAL", "0"));
        //.MustAsync(CityMustExistsAsync)
        //.WithErrorCode(nameof(CityIdNotExists))
        //.WithMessage(CityIdNotExists);

        When(e => e.ParentId.HasValue, () =>
        {
            RuleFor(e => e.ParentId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithErrorCode(nameof(ParentIdMinVal))
                .WithMessage(ParentIdMinVal.Replace("#VAL", "0"))
                .MustAsync(ParentAddressMustExistsAsync)
                .WithErrorCode(nameof(ParentIdNotExists))
                .WithMessage(ParentIdNotExists);
        });

        RuleFor(e => e.RedispatchDescription)
            .MaximumLength(65)
            .WithErrorCode(nameof(RedispatchDescriptionMaxLenght))
            .WithMessage(RedispatchDescriptionMaxLenght.Replace("#LENGTH", "65"));

        When(e => e.WindowDeliveryBegin.HasValue, () =>
        {
            RuleFor(e => e.WindowDeliveryBegin)
                .GreaterThan(DateTime.MinValue)
                .WithErrorCode(nameof(WindowDeliveryBeginMinVal))
                .WithMessage(WindowDeliveryBeginMinVal.Replace("#VAL", DateTime.MinValue.ToString("G", new CultureInfo("pt-BR"))));

            When(e => e.WindowDeliveryFinal.HasValue, () =>
            {
                RuleFor(e => e.WindowDeliveryFinal)
                    .GreaterThan(e => e.WindowDeliveryBegin)
                    .WithErrorCode(nameof(WindowDeliveryFinalMinVal))
                    .WithMessage(e => WindowDeliveryFinalMinVal.Replace("#VAL", e.WindowDeliveryBegin.Value.ToString("G", new CultureInfo("pt-BR"))));
            });
        }).Otherwise(() =>
        {
            RuleFor(e => e.WindowDeliveryFinal)
                .Null()
                .WithErrorCode(nameof(WindowDeliveryFinalShouldBeNull))
                .WithMessage(WindowDeliveryFinalShouldBeNull);
        });

        When(e => e.RestrictWindowDeliveryBegin.HasValue, () =>
        {
            RuleFor(e => e.RestrictWindowDeliveryBegin)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(DateTime.MinValue)
                .WithErrorCode(nameof(RestrictWindowDeliveryBeginMinVal))
                .WithMessage(RestrictWindowDeliveryBeginMinVal.Replace("#VAL", DateTime.MinValue.ToString("G", new CultureInfo("pt-BR"))))
                .Must(NoConflictBetweenWindowDelivery)
                .WithErrorCode(nameof(ConflictBetweenWindowDelivery))
                .WithMessage(ConflictBetweenWindowDelivery);

            When(e => e.RestrictWindowDeliveryFinal.HasValue, () =>
            {
                RuleFor(e => e.RestrictWindowDeliveryFinal)
                    .GreaterThan(e => e.RestrictWindowDeliveryBegin)
                    .WithErrorCode(nameof(RestrictWindowDeliveryFinalMinVal))
                    .WithMessage(e => RestrictWindowDeliveryFinalMinVal.Replace("#VAL", e.RestrictWindowDeliveryBegin.Value.ToString("G", new CultureInfo("pt-BR"))));
            });
        }).Otherwise(() =>
        {
            RuleFor(e => e.RestrictWindowDeliveryFinal)
                .Null()
                .WithErrorCode(nameof(RestrictWindowDeliveryFinalShouldBeNull))
                .WithMessage(RestrictWindowDeliveryFinalShouldBeNull);
        });
    }

    private bool ValidType(string type)
    {
        return Types.Contains(type);
    }

    private async Task<bool> PersonMustExistsAsync(int? idPerson, CancellationToken token)
    {
        return await _personRepository.AnyAsync(e => e.Id == idPerson);
    }

    private bool ValidOrigin(string origin)
    {
        return Origins.Contains(origin);
    }

    //private async Task<bool> CityMustExistsAsync(int cityId, CancellationToken token)
    //{
    //    //Se mapeado o contexto da base CTE mesmo não tenha vinculo direto por se tratar
    //    //de base distintas, mesmo assim dá para validar através do respositório e garantir
    //    //que a cidade exista ou se não dar uma mensangem de erro.
    //    return _cityRepository.AnyAsync(e => e.Id == cityId);
    //}

    private async Task<bool> ParentAddressMustExistsAsync(int? parentId, CancellationToken token)
    {
        return await _addressRepository.AnyAsync(e => e.Id == parentId);
    }

    private bool NoConflictBetweenWindowDelivery(Address entity, DateTime? date)
    {
        var windowDeliveryBegin = entity.WindowDeliveryBegin ?? DateTime.MinValue;
        var windowDeliveryFinal = entity.WindowDeliveryFinal ?? windowDeliveryBegin.Date.Add(new TimeSpan(0,23,59,59));

        if (entity.RestrictWindowDeliveryBegin.HasValue && entity.RestrictWindowDeliveryFinal.HasValue
        && (
            (entity.RestrictWindowDeliveryBegin >= windowDeliveryBegin && entity.RestrictWindowDeliveryBegin <= windowDeliveryFinal)
            || (entity.RestrictWindowDeliveryFinal >= windowDeliveryBegin && entity.RestrictWindowDeliveryFinal <= windowDeliveryFinal)
            )
        )
        {
            return false;
        }

        if (entity.RestrictWindowDeliveryBegin.HasValue && !entity.RestrictWindowDeliveryFinal.HasValue
        && entity.RestrictWindowDeliveryBegin >= windowDeliveryBegin && entity.RestrictWindowDeliveryBegin <= windowDeliveryFinal)
        {
            return false;
        }
    
        return true;
    }

    //private async Task<bool> UserExistsAsync(int userId, CancellationToken token)
    //{
    //    return _userRepository.AnyAsync(e => e.Id == userId);
    //}

    public async Task<bool> IsValidAsync(Address entity)
    {
        ValidationResult = await ValidateAsync(entity);
        return ValidationResult.IsValid;
    }
}
