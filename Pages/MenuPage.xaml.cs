using System;
using System.Collections.Generic;
using System.IO;
using Contatos.Models;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace Contatos.Pages
{
    public partial class MenuPage : ContentPage
    {
        List<Menu> menuItens;
        public string imagem { get; set; }
        MediaFile arquivoMidia;

        public MenuPage()
        {
            InitializeComponent();
            gerarMenu();
            geraUsuario();
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

       
        public async void geraUsuario()
        {
            var usuario = await App.Database.GetUsuariosAsync();

            if (usuario != null)
            {
                if (usuario.Imagem == "foto.png")
                { // Se a foto padrao tiver salva no banco
                    imgFoto.Source = usuario.Imagem;
                    imgFoto.Aspect = Aspect.AspectFill;
                }
                else
                { // Se a imagem foi alterada por uma da câmera
                    imgFoto.Source = ImageSource.FromFile(usuario.Imagem);
                    imgFoto.Aspect = Aspect.AspectFill;
                }
                lblNome.Text = usuario.Nome;
                lblEmail.Text = usuario.Email;

            }
            else
            {
                imgFoto.Source = "foto.png";
                lblNome.Text = "Reginaldo Morikawa";
                lblEmail.Text = "morikawa77@gmail.com";

                Usuario item = new Usuario()
                {
                    Imagem = "foto.png",
                    Nome = lblNome.Text,
                    Email = lblEmail.Text
                };
                await App.Database.SaveUsuarioAsync(item);
            }

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
            var opcao = await App.DialogoOpcoes("Escolha uma nova imagem:", "Fechar", "Câmera", "Galeria");

            if (opcao == "Câmera") {
                // Pega a foto tirada na câmera
                arquivoMidia = await Contatos.Helpers.CameraHelper.TirarFotoAsync("foto");
            } else if (opcao == "Galeria"){
                // Pega foto da galeria
                arquivoMidia = await Contatos.Helpers.CameraHelper.EscolheFotoAsync();
            }

            ExibirFoto();
        }

        private async void ExibirFoto()
        {
            // Verifica se existe uma foto para exibição
            if (arquivoMidia != null)
            {
                // Armazena o caminho onde esta a foto tirada
                string caminhoFoto = arquivoMidia.Path;

                // seta o source da imagem
                imgFoto.Source = ImageSource.FromFile(caminhoFoto);
                imgFoto.Aspect = Aspect.AspectFill;

                // cria instancia do usuario para salvar no banco
                Usuario item = new Usuario()
                {
                    Id = 1,
                    Nome = lblNome.Text,
                    Email = lblEmail.Text,
                    Imagem = caminhoFoto
                };

                // salva a alteração no banco
                await App.Database.SaveUsuarioAsync(item);
            }
        }

        async void usuarioTapped(object sender, EventArgs e)
        {
            await App.NavegacaoPagina((Page)Activator.CreateInstance(typeof(UsuarioEdicaoPage)));

        }


    }
}
