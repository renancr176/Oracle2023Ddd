using FluentValidation;
using FluentValidation.Results;
using Oracle2023Ddd.Domain.Core.DomainObjects;
using Oracle2023Ddd.Domain.TmsContext.Entities;
using Oracle2023Ddd.Domain.TmsContext.Interfaces.Repositories;
using Oracle2023Ddd.Domain.TmsContext.Interfaces.Validators;

namespace Oracle2023Ddd.Domain.TmsContext.Validators;

public class CustomerValidator : 
    EntityValidator<Customer>, 
    ICustomerValidator
{
    private static IEnumerable<int> IdCompanies = new[] { 1, 22 };

    #region Consts



    #endregion

    public ValidationResult ValidationResult { get; private set; }

    private readonly ICustomerRepository _customerRepository;
    private readonly IPersonValidator _personValidator;

    public CustomerValidator(ICustomerRepository customerRepository, IPersonValidator personValidator)
    {
        _customerRepository = customerRepository;
        _personValidator = personValidator;

        RuleFor(e => e.Person)
            .SetValidator(_personValidator);

        RuleFor(e => e.IdCompany)
            .Must(idCompany => IdCompanies.Any(id => id == idCompany));

        RuleFor(e => e.CommercialClassification);
    }

    public async Task<bool> IsValidAsync(Customer entity)
    {
        ValidationResult = await ValidateAsync(entity);
        return ValidationResult.IsValid;
    }
}