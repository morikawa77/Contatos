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
            dataMinimaDataAtual();
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
            // Tentei com (item.Nome == null) e com (item.Nome == null && item.Nome == "") mas ainda nao verifica se só tem espaços
            if (String.IsNullOrWhiteSpace(item.Nome)){
                await DisplayAlert("Erro ao salvar", "Digite o nome", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Local)) {
                await DisplayAlert("Erro ao salvar", "Digite o local", "Fechar");
            } else if (item.Data == null) {
                await DisplayAlert("Erro ao salvar", "Escolha a data", "Fechar");
            } else if(item.Data.Date < DateTime.Now.Date) { // .Date compara só a data sem o horário
                await DisplayAlert("Erro ao salvar", "Data escolhida é anterior a data atual", "Fechar");  
            } else if (String.IsNullOrWhiteSpace(item.HoraInicio)) {
                await DisplayAlert("Erro ao salvar", "Digite a hora de início", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.HoraTermino)) {
                await DisplayAlert("Erro ao salvar", "Digite a hora de termino", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Anotacoes)) {
                await DisplayAlert("Erro ao salvar", "Digite a anotação", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Status)) {
                await DisplayAlert("Erro ao salvar", "Escolha o status", "Fechar");
            } else if (!(String.IsNullOrWhiteSpace(item.Nome)) && !(String.IsNullOrWhiteSpace(item.Local)) && item.Data != null && item.Data.Date > DateTime.Now.Date && !(String.IsNullOrWhiteSpace(item.HoraInicio)) && !(String.IsNullOrWhiteSpace(item.HoraTermino)) && !(String.IsNullOrWhiteSpace(item.Anotacoes)) && !(String.IsNullOrWhiteSpace(item.Status))){
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

        private void dataMinimaDataAtual (){
            dPicData.MinimumDate = DateTime.Now;
        }

    }
}
