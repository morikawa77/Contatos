using Contatos.Models;
using Contatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contatos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PessoaEdicaoPage : ContentPage
    {
        public PessoaViewModelMem ViewModel { get; set; }
        public PessoaEdicaoPage()
        {
            InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            //item = new Pessoa();

            // Definir a ligação com os controles
            //this.BindingContext = item;

            // Instanciar a viewmodel
            //vm = new PessoaViewModelMem();


        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            // Retornar para a página anterior
            await Navigation.PopAsync();
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Contatos", "Nome do contato: " + txtNome.Text, "Fechar");

            //Fazer a operação de conversão
            Pessoa item = (Pessoa)this.BindingContext;

            ViewModel.Salvar(item);

            //var qtdItens = vm.Lista.Count();

            //DisplayAlert("Número de registros", qtdItens.ToString(), "Fechar");

            // Retornar para a página anterior

            await Navigation.PopAsync();
        }
    }
}