using FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Login;
using FluentValidation;
using System.Security.Principal;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Usuarios
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public int EmpresaId { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
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
