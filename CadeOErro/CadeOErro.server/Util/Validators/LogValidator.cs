using AutoMapper;
using CadeOErro.Domain.Models;
using CadeOErro.Server.DTOs.Log;
using CadeOErro.Server.DTOs.LogLevel;
using FluentValidation;
using FluentValidation.Results;

namespace CadeOErro.Server.Util.Validators
{
    public class LogValidator : AbstractValidator<Log>
    {
        private readonly IMapper _mapper;
        public LogValidator(IMapper mapper)
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

        private void ValidateTitle()
        {
            RuleFor(c => c.title)
                .NotEmpty().WithMessage("'Title' não pode ser vazio.")
                .MaximumLength(50).WithMessage("'Title' não pode ter mais de 50 caracteres.");

        }

        private void ValidateDescription()
        {
            RuleFor(c => c.description)
                .MaximumLength(255).WithMessage("'Description' não pode ter mais de 255 caracteres.");
        }

        private void ValidateSource()
        {
            RuleFor(c => c.source)
                .NotEmpty().WithMessage("'Source' não pode ser vazio.")
                .MaximumLength(255).WithMessage("'Source' não pode ter mais de 255 caracteres.");
        }

        private void ValidateIdUser()
        {
            RuleFor(c => c.idUser)
                .NotEmpty().WithMessage("'IdUser' não pode ser vazio.");
        }
        private void ValidateIdEnvironment()
        {
            RuleFor(c => c.idEnvironment)
                .NotEmpty().WithMessage("'IdEnvironment' não pode ser vazio.");
        }

        private void ValidateFrequency()
        {
            RuleFor(c => c.frequency)
                .GreaterThan(0).WithMessage("'Frequency' precisa ser superior a 0");
        }

        private void ValidateIdLogLevel()
        {
            RuleFor(c => c.idLogLevel)
                .NotEmpty().WithMessage("'IdLogLevel' não pode ser vazio.");
        }

        #endregion

        private void ValidateAllSaveProperties()
        {
            ValidateTitle();
            ValidateDescription();
            ValidateIdEnvironment();
            ValidateIdLogLevel();
            ValidateIdUser();
            ValidateSource();
            ValidateFrequency();
        }

        public virtual bool IsValid(Log log)
        {

            ValidateAllSaveProperties();
            ValidateId();

            ValidationResult = Validate(log);

            return ValidationResult.IsValid;
        }

        public bool IsValidSaveDTO(LogSaveDTO dto)
        {
            Log log = _mapper.Map<Log>(dto);

            ValidateAllSaveProperties();

            ValidationResult = Validate(log);

            return ValidationResult.IsValid;
        }

        public bool IsValidUpdateDTO(LogUpdateDTO dto)
        {
            Log log = _mapper.Map<Log>(dto);

            return IsValid(log);
        }
    }
}
