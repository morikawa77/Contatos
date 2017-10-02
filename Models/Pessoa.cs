using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Models
{
   public  class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Observacao { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string no,string ema,string tele,string obs)
        {
            this.Nome = no;
            this.Email = ema;
            this.Telefone = tele;
            this.Observacao = obs;
        }
    }
}
