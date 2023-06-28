using System.ComponentModel.DataAnnotations;

namespace FCX_Labs.Models
{
    public class ChangePassModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail")]
        public string email { get; set; }
    }
}