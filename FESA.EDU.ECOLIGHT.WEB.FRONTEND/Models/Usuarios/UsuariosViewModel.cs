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
}
