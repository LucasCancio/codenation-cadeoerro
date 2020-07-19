using AutoMapper;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs.EnvironmentDTO;
using FluentValidation;
using FluentValidation.Results;

namespace CadeOErro.Server.Util.Validators
{
    public class EnvironmentValidator : AbstractValidator<Environment>
    {
        private readonly IMapper _mapper;
        public EnvironmentValidator(IMapper mapper)
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

        private void ValidateShortName()
        {
            RuleFor(c => c.shortName)
                .NotEmpty().WithMessage("'ShortName' não pode ser vazio.")
                .MaximumLength(10).WithMessage("'Description' não pode ter mais de 10 caracteres.");

        }
        #endregion

        public virtual bool IsValid(Environment environment)
        {
            ValidateId();
            ValidateDescription();
            ValidateShortName();

            ValidationResult = Validate(environment);

            return ValidationResult.IsValid;
        }

        public bool IsValidSaveDTO(EnvironmentSaveDTO dto)
        {
            Environment environment = _mapper.Map<Environment>(dto);

            return IsValid(environment);
        }
    }
}
