using System;
using System.Collections.Generic;
using Contatos.Models;
using Xamarin.Forms;

namespace Contatos.Pages
{
    public partial class PessoaEdicaoPage : ContentPage
    {
        private Pessoa item; 
        
        void btn_Salvar_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Contatos", "Nome do Contato: " + txtNome.Text, "Fechar");
        }

        void btn_Cancelar_Clicked(object sender, System.EventArgs e)
        {
            
        }

        public PessoaEdicaoPage()
        {
            InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            // Instanciar o Objeto
            item = new Pessoa()
            {
                Nome = "Fulano",
                Email = "fulano@gmail.com",
                Telefone = "12345",
                Observacao = "Obs..."
            };

            // Definição de ligar os controles
            this.BindingContext = item;
        }
    }
}
