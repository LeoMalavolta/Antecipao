using Antecipacao.Application.VaidationMessages;
using FluentValidation;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.AdicionarNota
{
    public class AdicionarNotaCommandValidation : AbstractValidator<AdicionarNotaCommand>
    {
        public AdicionarNotaCommandValidation()
        {
            RuleFor(x => x.idEmpresa)
                .NotEmpty().WithMessage(ValidationMessages.ID_EMPTY_ERROR);
            RuleFor(x => x.idNota)
                .NotEmpty().WithMessage(ValidationMessages.ID_EMPTY_ERROR);
        }
    }
}
