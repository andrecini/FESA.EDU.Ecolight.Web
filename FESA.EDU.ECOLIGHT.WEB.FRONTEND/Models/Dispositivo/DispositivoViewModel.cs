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
}
