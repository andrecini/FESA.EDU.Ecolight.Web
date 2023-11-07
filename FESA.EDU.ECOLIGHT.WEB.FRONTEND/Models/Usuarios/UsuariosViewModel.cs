using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using FluentValidation;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Usuarios
{
    public class UsuariosViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("username")]
        public string Nome { get; set; }
        
        [JsonIgnore]
        public string Sobrenome { get; set; }
        
        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }
        
        [JsonPropertyName("empresaId")]
        public int EmpresaId { get; set; }
        
        [JsonPropertyName("celular")]
        public string Celular { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Senha { get; set; }

        [JsonPropertyName("uf")]
        public int Uf { get; set; }

        [JsonIgnore]
        public string Confirmacao { get; set; }

    }

    public class UsuariosViewModelValidator : AbstractValidator<UsuariosViewModel>
    {
        public UsuariosViewModelValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("É obrigatório informar o Nome!");
            RuleFor(x => x.Sobrenome).NotEmpty().NotNull().WithMessage("É obrigatório informar o Sobrenome!");
            RuleFor(x => x.Cpf).NotEmpty().NotNull().WithMessage("É obrigatório informar um Cpf");
            RuleFor(x => x.EmpresaId).GreaterThan(0).WithMessage("ID da empresa não identificado!");
            RuleFor(x => x.Celular).NotEmpty().NotNull().WithMessage("É obrigatório informar um Celular");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("É obrigatório informar o Email!");
            RuleFor(x => x.Senha).NotEmpty().NotNull().WithMessage("É obrigatório informar a Senha!");
            RuleFor(x => x.Confirmacao).NotEmpty().NotNull().WithMessage("É obrigatório informar a Confirmação da Senha!");
        }
    }
}
