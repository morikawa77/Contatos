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
        }

        private void gerarMenu()
        {
            
            imgFoto.Source = ImageSource.FromResource("Contatos.Resources.Imagens.foto.png");

            lblNome.Text = "Reginaldo Morikawa";
            lblEmail.Text = "morikawa77@gmail.com";
            lblNome.FontSize = 12;
            lblEmail.FontSize = 12;
            lblNome.FontAttributes = FontAttributes.Bold;

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
        }
        // IPicturePicker Interface Multiplataform from https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/dependency-service/photo-picker/
    }
}
