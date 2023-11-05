using FluentValidation;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao
{
    public class AutomacaoViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Nome { get; set; }
        [JsonPropertyName("onDate")]
        public TimeOnly Inicio { get; set; }
        [JsonPropertyName("offDate")]
        public TimeOnly Fim { get; set; }
        [JsonPropertyName("brightness")]
        public int Brilho { get; set; }
        [JsonPropertyName("deviceId")]
        public int DispositivoId { get; set; }
        [JsonPropertyName("enable")]
        public bool Ativo { get; set; }
    }

    public class AutomacaoViewModelValidator : AbstractValidator<AutomacaoViewModel>
    {
        public AutomacaoViewModelValidator() 
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("É obrigatório dar um nome para a Automação!");
            RuleFor(x => x.Inicio).Must(x => x != TimeOnly.MinValue).WithMessage("É obrigatório definir o horário de Início da Automação!");
            RuleFor(x => x.Fim).Must(x => x != TimeOnly.MinValue).WithMessage("É obrigatório definir o horário de Fim da Automação!");
            RuleFor(x => x.Brilho).GreaterThan(-1).LessThan(101).WithMessage("O Brilho da lâmpada deve ser um valor entre 0 e 100%!");
            RuleFor(x => x.Id).Must(x => x > 0).WithMessage("ID da empresa não identificado!");
        }

    }
}
