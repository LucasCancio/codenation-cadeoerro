using AutoMapper;
using CadeOErro.Domain.Interfaces.Repositories;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs.Login;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Util.Validatons;
using FluentValidation;
using FluentValidation.Results;

namespace CadeOErro.Server.Util.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public UserValidator(IMapper mapper, IUserRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
        public ValidationResult ValidationResult { get; private set; }

        #region Validate Methods

        private void ValidateId()
        {
            RuleFor(c => c.id)
                .NotEmpty().WithMessage("'Id' não pode ser vazio.");

        }

        private void ValidateName()
        {
            RuleFor(c => c.name)
                .NotEmpty().WithMessage("'Name' não pode ser vazio.");

        }

        private void ValidatePassword()
        {
            RuleFor(c => c.password)
                .NotEmpty().WithMessage("'Password' não pode ser vazio.");

        }

        private void ValidateEmail(bool unique = false)
        {
            var emailValidation = new EmailValidation(_repository);
            RuleFor(c => c.email)
                .NotEmpty().WithMessage("'Email' não pode ser vazio.")
                .EmailAddress().WithMessage("Email inválido.");

            if (unique) RuleFor(c => c.email).Must(emailValidation.IsUnique).WithMessage("O Email já esta em uso.");

        }

        private void ValidateCPF(bool unique = false)
        {
            var cpfValidation = new CPFValidation(_repository);

            RuleFor(c => c.cpf)
                .NotEmpty().WithMessage("'CPF' não pode ser vazio.")
                .Must(CPFValidation.IsCpf).WithMessage("CPF inválido.");

            if (unique) RuleFor(c => c.password).Must(cpfValidation.IsUnique).WithMessage("O CPF já esta em uso.");

        }

        private void ValidateRole()
        {
            RuleFor(c => c.role)
                .NotEmpty().WithMessage("'Role' não pode ser vazio.")
                .Must(RoleValidation.IsRole).WithMessage("Role inválida! Escolha entre 'admin' ou 'user'");

        }
        #endregion

        private void ValidateAllProperties()
        {
            ValidateCPF();
            ValidateEmail();
            ValidateId();
            ValidateName();
            ValidatePassword();
            ValidateRole();
        }

        public virtual bool IsValid(User user)
        {

            ValidateAllProperties();

            ValidationResult = Validate(user);

            return ValidationResult.IsValid;
        }

        public bool IsValidCreateDTO(UserCreateDTO dto)
        {
            User user = _mapper.Map<User>(dto);

            ValidateName();
            ValidatePassword();
            ValidateEmail(unique: true);
            ValidateCPF(unique: true);
            ValidateRole();

            ValidationResult = Validate(user);

            return ValidationResult.IsValid;
        }

        public bool IsValidUpdateDTO(UserUpdateDTO dto)
        {
            User user = _mapper.Map<User>(dto);

            ValidateId();
            ValidateName();
            ValidatePassword();
            ValidateRole();

            ValidationResult = Validate(user);

            return ValidationResult.IsValid;
        }

        public bool IsValidPasswordDTO(PasswordDTO dto)
        {
            User user = _mapper.Map<User>(dto);

            ValidateEmail();
            ValidateCPF();

            ValidationResult = Validate(user);

            return ValidationResult.IsValid;
        }

        public bool IsValidLoginDTO(LoginDTO dto)
        {
            User user = _mapper.Map<User>(dto);

            ValidateEmail();
            ValidatePassword();

            ValidationResult = Validate(user);

            return ValidationResult.IsValid;
        }

    }
}
