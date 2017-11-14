using System;
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

        Usuario usuario = new Usuario();

        async void getUsuario(){
            usuario = await App.Database.GetUsuariosAsync();
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
            //usuario = (Usuario)this.BindingContext;

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

            if (String.IsNullOrWhiteSpace(lbl_nome.Text)){
                await DisplayAlert("Erro ao salvar", "Digite o nome", "Fechar");
            } else if (String.IsNullOrWhiteSpace(lbl_email.Text)) {
                await DisplayAlert("Erro ao salvar", "Digite o email", "Fechar");
            } else if (!isValidEmail(lbl_email.Text)){
                await DisplayAlert("Erro ao salvar", "E-mail inválido", "Fechar");
            } 
            else if (!(String.IsNullOrWhiteSpace(lbl_nome.Text)) && !(String.IsNullOrWhiteSpace(lbl_email.Text)))
            {
                Usuario item = new Usuario()
                {
                    Id = usuario.Id,
                    Imagem = usuario.Imagem,
                    Nome = lbl_nome.Text,
                    Email = lbl_email.Text
                };
                // salva usuario no banco
                await App.Database.SaveUsuarioAsync(item);
                // atualiza campos de texto na MenuPage
                // await ???
                // avisa o usuario que deu certo
                await DisplayAlert("Sucesso", "Usuário atualizado", "Fechar");
                // volta para página anterior
                await Navigation.PopAsync();
            }
        }
    }
}
