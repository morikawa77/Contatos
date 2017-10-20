using System;
namespace Contatos.Models
{
    public class Evento
    {
        public Evento()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public string Anotacoes { get; set; }
        public string Status { get; set; }


    }
}
