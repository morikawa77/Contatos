using System;
using System.Collections.Generic;
using System.IO;
using Contatos.Models;
using Xamarin.Forms;

namespace Contatos.Pages
{
    public partial class MenuPage : ContentPage
    {
        List<Menu> menuItens;
        public string imagem { get; set; }

        public MenuPage()
        {
            InitializeComponent();
            gerarMenu();
            // geraUsuario();
            geraUsuarioSemBanco();
        }

        private void gerarMenu()
        {

            var m1 = new Menu()
            {

                Titulo = "CONTATOS",
                Imagem = "pessoas.png",
                Paginas = typeof(PessoaListaPage)

            };

            var m2 = new Menu()
            {
                Titulo = "EVENTOS",
                Imagem = "eventos.png",
                Paginas = typeof(EventoListaPage)
            };

            menuItens = new List<Menu>();
            menuItens.Add(m1);
            menuItens.Add(m2);

            lvMenu.ItemsSource = menuItens;

        }

        /* NÃO TA FUNCIONANDO SAPORRA
        async void geraUsuario(){
            var usuario = await App.Database.GetUsuariosAsync();

            if (usuario != null)
            {
                imgFoto.Source = usuario.Imagem;
                lblNome.Text = usuario.Nome;
                lblEmail.Text = usuario.Email;


            } else
            {
                imgFoto.Source = ImageSource.FromResource("Contatos.Resources.Imagens.foto.png");
                lblNome.Text = "Reginaldo Morikawa";
                lblEmail.Text = "morikawa77@gmail.com";

                Usuario item = new Usuario()
                {
                    Imagem = (string)imgFoto.Source.GetValue(FileImageSource.FileProperty),
                    //Imagem = imgFoto.Source.ToString(),
                    Nome = lblNome.Text,
                    Email = lblEmail.Text
                };
                await App.Database.SaveUsuarioAsync(item);
            }

            lblNome.FontSize = 12;
            lblEmail.FontSize = 12;
            lblNome.FontAttributes = FontAttributes.Bold;
        }
        */

        void geraUsuarioSemBanco(){
            imgFoto.Source = ImageSource.FromResource("Contatos.Resources.Imagens.foto.png");
            lblNome.Text = "Reginaldo Morikawa";
            lblEmail.Text = "morikawa77@gmail.com";

            lblNome.FontSize = 12;
            lblEmail.FontSize = 12;
            lblNome.FontAttributes = FontAttributes.Bold;
        }

        async void lvMenu_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            // Remove a seleção da lista pra não ficar aquela cor ridícula marcada
            // Se acabou de remover não fazer nada
            if (e.Item == null) return;
            // Remove a seleção
            ((ListView)sender).SelectedItem = null;

            var item = (Menu)e.Item;
            await App.NavegacaoPagina((Page)Activator.CreateInstance(item.Paginas));

        }

        async void homeMenuTapped(object sender, EventArgs e)
        {
            await App.NavegacaoPaginaInicialAsync();
        }

        async void imgTapped(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();
            imgFoto.Source = ImageSource.FromStream(() => stream);

            /* Salvar uri da img no banco NÃO TA FUNCIONANDO :/
            var image = imgFoto.Source.GetValue(StreamImageSource.StreamProperty).ToString();
            Usuario item = (Usuario)this.BindingContext;
            item.Imagem = image;
            //item.Id = 1;
            await App.Database.SaveUsuarioAsync(item);
            */
        }
        // IPicturePicker Interface Multiplataform from https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/dependency-service/photo-picker/

        async void usuarioTapped(object sender, EventArgs e)
        {
            await App.NavegacaoPagina((Page)Activator.CreateInstance(typeof(UsuarioEdicaoPage)));

        }
    }
}
