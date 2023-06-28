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
    public class Person
    {
        
        public long id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string name { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string cpf { get; set; }
        public virtual string cpf_texto
        {
            get
            {
                if (cpf != null)
                    return cpf.ReturnCPF();
                return string.Empty;
            }
            set { this.cpf = value; }

        }  
        [EmailAddress(ErrorMessage = "E-Mail Inválido")]
        public string email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]      
        [Phone(ErrorMessage = "Telefone Inválido")]
        public string phone { get; set; }
        public DateTime birth { get; set; }
        public string birth_text { get { return Functions.DateTimeToString(birth); } }

        public string mother_name { get; set; }
        public string stats { get; set; }
        public DateTime insert_date { get; set; }
        public string insert_date_text { get { return Functions.DateTimeToString(insert_date); } }

        public DateTime alteration_date { get; set; }
        public string alteration_date_text { get { return Functions.DateTimeToString(alteration_date); } }


    }

}