using FCX_Labs.Enums;
using FCX_Labs.Helper;
using System;
using System.Collections.Generic;
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
        public string alteration_date_text { get { return Functions.DateTimeToString(alteration_date.GetValueOrDefault()); } }

        public virtual List<Person> Person { get; set; }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            password = novaSenha.GerarHash();
            return novaSenha;
        }

    }
}