using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contatos.Models
{
    public class Evento : INotifyPropertyChanged
    {
        public Evento()
        {
        }

        //Declarar os campos internos
        private int id;
        private string nome;
        private string local;
        private DateTime data;
        private string horaInicio;
        private string horaTermino;
        private string anotacoes;
        private string status;



        //Declarar as propriedades
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
        public string Local
        {
            get
            {
                return local;
            }
            set
            {
                local = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }
        public DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }
        public string HoraInicio
        {
            get
            {
                return horaInicio;
            }
            set
            {
                horaInicio = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }
        public string HoraTermino
        {
            get
            {
                return horaTermino;
            }
            set
            {
                horaTermino = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }
        public string Anotacoes
        {
            get
            {
                return anotacoes;
            }
            set
            {
                anotacoes = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
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