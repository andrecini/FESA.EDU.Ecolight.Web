using FluentValidation;
using System.Security.Cryptography;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Dispositivo
{
    public class DispositivoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get;set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
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
