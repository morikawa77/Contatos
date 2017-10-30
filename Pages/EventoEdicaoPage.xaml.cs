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
        public EventoViewModelMem ViewModel { get; set; }

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
            await App.Database.SaveEventoAsync(item);

            await Navigation.PopAsync();
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
