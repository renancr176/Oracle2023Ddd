﻿using FluentValidation;
using FluentValidation.Results;

namespace Oracle2023Ddd.Domain.Core.DomainObjects;

public interface IEntityValidator<TEntity> : IValidator<TEntity> where TEntity : Entity
{
    ValidationResult ValidationResult { get; }
    Task<bool> IsValidAsync(TEntity entity);
}