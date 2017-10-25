using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Models;
using Contatos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contatos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PessoaListaPage : ContentPage
    {
        private PessoaViewModelMem vm;


        public PessoaListaPage()
        {
            InitializeComponent();

            Inicializar();

            // Seta o título do botão voltar pra esta página FUNCIONA SÓ NO IOS
            NavigationPage.SetBackButtonTitle(this, "Lista de Contatos");

        }

        async void tbiNovo_Clicked(object sender, System.EventArgs e)
        {
            // Criar o objeto de binding
            var pessoa = new Pessoa();

            // Criar a página de edição
            var pagina = new PessoaEdicaoPage();

            // Definir o binding
            pagina.BindingContext = pessoa;
            // Atribuir a viewmodel
            pagina.ViewModel = vm;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }

        async void lvPessoa_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            // Obter o objeto selecionado
            var pessoa = (Pessoa)e.Item;

			// Criar a página de edição
			var pagina = new PessoaEdicaoPage();

			// Definir o binding
			pagina.BindingContext = pessoa;
			// Atribuir a viewmodel
			pagina.ViewModel = vm;


			// Chamar a página
			await Navigation.PushAsync(pagina);


        }

        // método para chamar página de eventos
        async void tbiEventos(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Contatos.Pages.EventoListaPage());
        }

        private void Inicializar()
        {
            //Instanciar a viewmodel
            vm = new PessoaViewModelMem();

            // Definir a fonte de dados da lista
            lvPessoa.ItemsSource = vm.Lista;

            // Criar registros de teste
            var p1 = new Pessoa()
            {
                Nome = "Reginaldo Morikawa",
                Email = "morikawa77@gmail.com",
                Telefone = "+5517981462389"
                   
            };

            // adicionar item na lista
            vm.Salvar(p1);


        }
    }
}