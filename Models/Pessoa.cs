﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Models
{
    public class Pessoa : INotifyPropertyChanged
    {
        //Declarar os campos internos
        private int id;
        private string nome;
        private string email;
        private string telefone;
        private string observacao;

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
        public string Nome { 
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
        public string Telefone
        {
            get
            {
                return telefone;
            }
            set
            {
                telefone = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }
        public string Observacao
        {
            get
            {
                return observacao;
            }
            set
            {
                observacao = value;
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