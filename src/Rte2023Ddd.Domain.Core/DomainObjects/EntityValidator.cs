using FluentValidation;
using Oracle2023Ddd.Domain.Core.Data;

namespace Oracle2023Ddd.Domain.Core.DomainObjects;

public abstract class EntityValidator<TEntity> : AbstractValidator<TEntity>
    where TEntity : Entity
{
    #region Consts

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

    //private readonly IUserRepository _userRepository;

    public EntityValidator(/*IUserRepository userRepository*/)
    {
        //_userRepository = userRepository;

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
    }

    //private async Task<bool> UserExistsAsync(int userId, CancellationToken token)
    //{
    //    return await _userRepository.Any(e => e.Id == userId);
    //}
}

public abstract class EntityStringIdValidator<TEntity> : EntityValidator<TEntity>
    where TEntity : EntityStringId
{
    #region Consts

    public const string IdIsRequired = "O Id é obrigatório.";
    public const string IdMinLength = "O Id deve possuir ao menos #LENGTH caracter(es).";
    public const string IdMaxLength = "O Id excedeu #LENGTH caracteres.";
    public const string IdAlreadyExists = "Existe outro registro com o mesmo ID.";

    #endregion

    private readonly IRepository<TEntity> _entityRepository;

    public EntityStringIdValidator(
        IRepository<TEntity> entityRepository, 
        int idMinLength, 
        int idMaxLength)
    {
        _entityRepository = entityRepository;

        RuleFor(e => e.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithErrorCode(nameof(IdIsRequired))
            .WithMessage(IdIsRequired)
            .NotEmpty()
            .WithErrorCode(nameof(IdIsRequired))
            .WithMessage(IdIsRequired)
            .MinimumLength(idMinLength)
            .WithErrorCode(nameof(IdMinLength))
            .WithMessage(IdMinLength.Replace("#LENGTH", $"{idMinLength}"))
            .MaximumLength(idMaxLength)
            .WithErrorCode(nameof(IdMaxLength))
            .WithMessage(IdMaxLength.Replace("#LENGTH", $"{idMaxLength}"))
            .MustAsync(IdUniqueAsync)
            .WithErrorCode(nameof(IdAlreadyExists))
            .WithMessage(IdAlreadyExists);
    }

    private async Task<bool> IdUniqueAsync(TEntity entity, string id, CancellationToken arg3)
    {
        return !await _entityRepository.AnyAsync(e => e.Id == id && e.CreatedAt != entity.CreatedAt);
    }
}