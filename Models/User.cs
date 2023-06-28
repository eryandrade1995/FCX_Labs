using FCX_Labs.Enums;
using FCX_Labs.Helper;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using FCX_Labs.Global.Utilities;
namespace FCX_Labs.Models
{
    public class User
    {
        public long id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string email { get; set; }

        public ProfileEnum? profile { get; set; }
        public string password { get; set; }

        public DateTime insert_date { get; set; }
        public DateTime? alteration_date { get; set; }

        public virtual List<Person> Person { get; set; }

        public bool PassOk(string senha)
        {
            return true;
            // return password == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            password = password.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            password = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            password = novaSenha.GerarHash();
            return novaSenha;
        }

    }
}