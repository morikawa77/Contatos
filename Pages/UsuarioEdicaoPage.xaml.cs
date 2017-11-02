using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Contatos.Models;
using Xamarin.Forms;

namespace Contatos.Pages
{
    public partial class UsuarioEdicaoPage : ContentPage
    {
        public UsuarioEdicaoPage()
        {
            InitializeComponent();
            getUsuario();
        }



        async void getUsuario(){
            Usuario usuario = await App.Database.GetUsuariosAsync();
            lbl_nome.Text = usuario.Nome;
            lbl_email.Text = usuario.Email;
        }


        async void btnCancelar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            //Fazer a operação de conversão
            Usuario item = (Usuario)this.BindingContext;

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

            if (String.IsNullOrWhiteSpace(item.Nome)){
                await DisplayAlert("Erro ao salvar", "Digite o nome", "Fechar");
            } else if (String.IsNullOrWhiteSpace(item.Email)) {
                await DisplayAlert("Erro ao salvar", "Digite o email", "Fechar");
            } else if (!isValidEmail(item.Email)){
                await DisplayAlert("Erro ao salvar", "E-mail inválido", "Fechar");
            } 
            else if (!(String.IsNullOrWhiteSpace(item.Nome)) && !(String.IsNullOrWhiteSpace(item.Email)))
            {
                // No bindable ele já ta pegando o objeto do item que contem o Id
                // item.Id = 1;
                await App.Database.SaveUsuarioAsync(item);
                await Navigation.PopAsync();
            }
        }
    }
}
