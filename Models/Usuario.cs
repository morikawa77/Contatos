using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Contatos.Models
{
    [Table("Usuario")]
    public class Usuario : INotifyPropertyChanged
    {
        

        private int id;
        private string nome;
        private string email;
        private string imagem;

        public Usuario()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }

        [MaxLength(250), NotNull]
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }
        [MaxLength(350), NotNull]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }

        [MaxLength(250), NotNull]
        public string Imagem
        {
            get
            {
                return imagem;
            }
            set
            {
                imagem = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Método para registrar a alteração da propriedade
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
