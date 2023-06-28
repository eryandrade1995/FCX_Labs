using System.ComponentModel.DataAnnotations;

namespace FCX_Labs.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Digite o login")]
        public string login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string password { get; set; }
    }
}