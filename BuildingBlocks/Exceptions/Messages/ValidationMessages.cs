namespace BuildingBlocks.Exceptions.Messages
{

    /// <summary>
    /// Classe responsável por armazenar mensagens padronizadas de validação.
    /// 
    /// Padrão adotado:
    /// - Todas as mensagens devem iniciar com "A propriedade {PropertyName}" para manter consistência.
    /// - Utilize placeholders do FluentValidation ({PropertyName}, {MinLength}, {MaxLength}, etc.) quando aplicável.
    /// - Escreva as mensagens em português claro e objetivo.
    /// - Nome das constantes sempre em MAIÚSCULO e com underscore (_) separando palavras.
    /// 
    /// Exemplo de uso:
    /// RuleFor(x => x.Email)
    ///     .NotEmpty().WithMessage(ValidationMessages.NOT_EMPTY)
    ///     .EmailAddress().WithMessage(ValidationMessages.EMAIL_INVALIDO);
    /// </summary>
    /// 
    public static class ValidationMessages
    {
        public const string NOT_NULL = "A propriedade {PropertyName} não pode ser nulo.";
        public const string NOT_EMPTY = "A propriedade {PropertyName} não pode ser vazio.";

        public const string EMAIL_INVALIDO = "A propriedade {PropertyName} deve ser um email válido.";

        public const string TAMANHO_MINIMO = "A propriedade {PropertyName} deve ter no mínimo {MinLength} caracteres.";
        public const string TAMANHO_MAXIMO = "A propriedade {PropertyName} deve ter no máximo {MaxLength} caracteres.";
    }
}
