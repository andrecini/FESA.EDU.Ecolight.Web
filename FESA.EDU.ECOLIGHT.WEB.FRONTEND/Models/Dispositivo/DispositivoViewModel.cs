using FluentValidation;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo
{
    public class DispositivoViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("deviceName")]
        public string Nome { get; set; }

        [JsonPropertyName("verificationCode")]
        public string Codigo { get; set; }

        [JsonPropertyName("lampAmount")]
        public int Quantidade { get; set; }

        [JsonPropertyName("localDescription")]
        public string Descricao { get; set; }

        [JsonPropertyName("enable")]
        public string Ativo { get; set; }

        [JsonPropertyName("usedKWH")]
        public float KwhUsados { get; set; }

        [JsonPropertyName("empresaId")]
        public int EmpresaId { get; set; }

        [JsonIgnore]
        public bool CheckAtivo { get; set; }
    }

    public class DispositivoViewModelValidator : AbstractValidator<DispositivoViewModel>
    {
        public DispositivoViewModelValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("É obrigatório informar um nome!");
            RuleFor(x => x.Codigo).NotEmpty().NotNull().WithMessage("É obrigatório informar o código!");
            RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage("A quantidade lâmpadas deve ser maior do que 0");
            RuleFor(x => x.Descricao).NotEmpty().NotNull().WithMessage("É obrigatório informar uma descrição!");
        }
    }

}
