using System;
using System.Collections.Generic;
using Contatos.Models;
using Xamarin.Forms;

namespace Contatos.Pages
{
    public partial class UsuarioEdicaoPage : ContentPage
    {
        public UsuarioEdicaoPage()
        {
            InitializeComponent();
        }

        async void btnCancelar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void btnSalvar_Clicked(object sender, System.EventArgs e)
        {
            Usuario item = (Usuario)this.BindingContext;

            if (String.IsNullOrWhiteSpace(item.Nome)){
                await DisplayAlert("Erro ao salvar", "Digite o nome", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Email)) {
                await DisplayAlert("Erro ao salvar", "Digite o email", "Fechar");
            } else if (!(String.IsNullOrWhiteSpace(item.Nome)) && !(String.IsNullOrWhiteSpace(item.Email)))
            {
                item.Id = 1;
                await App.Database.SaveUsuarioAsync(item);
                await Navigation.PopAsync();
            }
        }
    }
}
