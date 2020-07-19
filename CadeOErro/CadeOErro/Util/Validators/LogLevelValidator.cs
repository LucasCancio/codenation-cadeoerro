using AutoMapper;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs.LogLevel;
using FluentValidation;
using FluentValidation.Results;

namespace CadeOErro.Server.Util.Validators
{
    public class LogLevelValidator : AbstractValidator<LogLevel>
    {
        private readonly IMapper _mapper;
        public LogLevelValidator(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public ValidationResult ValidationResult { get; private set; }

        #region Validate Methods

        private void ValidateId()
        {
            RuleFor(c => c.id)
                .NotEmpty().WithMessage("'Id' não pode ser vazio.");

        }

        private void ValidateDescription()
        {
            RuleFor(c => c.description)
                .NotEmpty().WithMessage("'Description' não pode ser vazio.")
                .MaximumLength(50).WithMessage("'Description' não pode ter mais de 50 caracteres.");

        }

        #endregion

        public virtual bool IsValid(LogLevel logLevel)
        {
            ValidateId();
            ValidateDescription();

            ValidationResult = Validate(logLevel);

            return ValidationResult.IsValid;
        }

        public bool IsValidSaveDTO(LogLevelSaveDTO dto)
        {
            LogLevel logLevel = _mapper.Map<LogLevel>(dto);

            return IsValid(logLevel);
        }
    }
}
