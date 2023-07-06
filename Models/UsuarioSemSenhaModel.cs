using FCX_Labs.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FCX_Labs.Models
{
    public class UsuarioSemSenhaModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public ProfileEnum? profile { get; set; }
    }
}