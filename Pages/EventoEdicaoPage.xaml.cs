using System;
using System.Collections.Generic;
using Contatos.Models;
using Contatos.ViewModels;
using Xamarin.Forms;

namespace Contatos.Pages
{
    public partial class EventoEdicaoPage : ContentPage
    {
        List<string> listaStatus;
        // public EventoViewModelMem ViewModel { get; set; }

        public EventoEdicaoPage()
        {
            InitializeComponent();
            ListarStatus();
        }

        private void ListarStatus()
        {
            listaStatus = new List<string>();
            listaStatus.Add("Ocupado");
            listaStatus.Add("Disponível");
            listaStatus.Add("Provisório");
            listaStatus.Add("Atividade Externa");

            picStatus.ItemsSource = listaStatus;
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            // Retornar para a página anterior
            await Navigation.PopAsync();
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {

            //Fazer a operação de conversão
            Evento item = (Evento)this.BindingContext;

            // ViewModel.Salvar(item);

            if (item.Nome == null){
                await DisplayAlert("Erro ao salvar", "Digite o nome", "Fechar");
            } else if (item.Local == null) {
                await DisplayAlert("Erro ao salvar", "Digite o local", "Fechar");
            } else if (item.Data == null) {
                await DisplayAlert("Erro ao salvar", "Escolha a data", "Fechar");
            } else if (item.HoraInicio == null) {
                await DisplayAlert("Erro ao salvar", "Digite a hora de início", "Fechar");
            } else if (item.HoraTermino == null) {
                await DisplayAlert("Erro ao salvar", "Digite a hora de termino", "Fechar");
            } else if (item.Anotacoes == null) {
                await DisplayAlert("Erro ao salvar", "Digite a anotação", "Fechar");
            } else if (item.Status == null) {
                await DisplayAlert("Erro ao salvar", "Escolha o status", "Fechar");
            } else if (item.Nome != null && item.Local != null && item.Data != null && item.HoraInicio != null && item.HoraTermino != null && item.Anotacoes != null && item.Status != null){
                await App.Database.SaveEventoAsync(item);
                await Navigation.PopAsync();
            }

        }

        private async void btnApagar_Clicked(object sender, EventArgs e)
        {
            //Fazer a operação de conversão
            Evento item = (Evento)this.BindingContext;

            await App.Database.DeleteEventoAsync(item);

            await Navigation.PopAsync();

        }

    }
}
