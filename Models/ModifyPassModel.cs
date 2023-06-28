using System.ComponentModel.DataAnnotations;

namespace FCX_Labs.Models
{
    public class ModifyPassModel
    {
        public long id { get; set; }

        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        public string old_pass { get; set; }

        [Required(ErrorMessage = "Digite a nova senha do usuário")]
        public string new_pass { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha do usuário")]
        [Compare("new_pass", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmPass { get; set; }
    }
}