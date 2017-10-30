using System;
using SQLite;

namespace Contatos.Models
{
    [Table("usuario")]
    public class Usuario
    {
        public Usuario()
        {
        }
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(250), NotNull]
        public string nome { get; set; }

        [MaxLength(350), NotNull]
        public string email { get; set; }

        [MaxLength(800), NotNull]
        public string imagem { get; set; }
    }
}
