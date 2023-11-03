using System.Security.Cryptography;

namespace FESA.EDU.ECOLIGHT.WEB.FRONTEND.Models.Automacao
{
    public class AutomacaoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TimeOnly Inicio { get; set; }
        public TimeOnly Fim { get; set; }
        public int Brilho { get; set; }
        public int DispositivoId { get; set; }
        public bool Ativo { get; set; }
    }
}
