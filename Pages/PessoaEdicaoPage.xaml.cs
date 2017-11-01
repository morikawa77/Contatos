using Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace Contatos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PessoaEdicaoPage : ContentPage
    {
        //public PessoaViewModelMem ViewModel { get; set; }
        public PessoaEdicaoPage()
        {
            InitializeComponent();

            //Inicializar();
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

            // RegExp to validate email
            bool isValidEmail(string inputEmail)
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(inputEmail))
                    return (true);
                else
                    return (false);
            }

            if(String.IsNullOrWhiteSpace(item.Nome)){
                await DisplayAlert("Erro ao salvar", "Digite o nome", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Email)){
                await DisplayAlert("Erro ao salvar", "Digite o e-mail", "Fechar");
            } else if (!isValidEmail(item.Email)) {
                await DisplayAlert("Erro ao salvar", "E-mail inválido", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Telefone)){
                await DisplayAlert("Erro ao salvar", "Digite o telefone", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Observacao)) {
                await DisplayAlert("Erro ao salvar", "Digite a observação", "Fechar");
            } else if (!(String.IsNullOrWhiteSpace(item.Nome)) && !(String.IsNullOrWhiteSpace(item.Email)) && (isValidEmail(item.Email)) && !(String.IsNullOrWhiteSpace(item.Telefone)) && !(String.IsNullOrWhiteSpace(item.Observacao))){
                // salva no banco
                await App.Database.SavePessoaAsync(item);
                // Retornar para a página anterior
                await Navigation.PopAsync();
            }
            // ViewModel.Salvar(item);
            // await App.Database.SavePessoaAsync(item);

            //var qtdItens = vm.Lista.Count();

            //DisplayAlert("Número de registros", qtdItens.ToString(), "Fechar");


        }

        private async void btnApagar_Clicked(object sender, EventArgs e)
        {
            //Fazer a operação de conversão
            Pessoa item = (Pessoa)this.BindingContext;

            await App.Database.DeletePessoaAsync(item);

            await Navigation.PopAsync();

        }
    }
}