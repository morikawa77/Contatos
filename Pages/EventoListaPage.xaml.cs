using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Contatos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoListaPage : ContentPage
    {
        //private EventoViewModelMem vm;


        public EventoListaPage()
        {
            InitializeComponent();
            //Inicializar();
            OnAppearing();
        }

        async void tbiNovo_Clicked(object sender, System.EventArgs e)
        {
            // Criar o objeto de binding
            var evento = new Evento();

            // Criar a página de edição
            var pagina = new EventoEdicaoPage();

            // Definir o binding
            pagina.BindingContext = evento;
            // Atribuir a viewmodel
            // pagina.ViewModel = vm;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }

        async void lvEvento_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            // Obter o objeto selecionado
            var evento = (Evento)e.Item;

            // Criar a página de edição
            var pagina = new EventoEdicaoPage();

            // Definir o binding
            pagina.BindingContext = evento;
            // Atribuir a viewmodel
            // pagina.ViewModel = vm;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }



        /* private void Inicializar()
        {
            //Instanciar a viewmodel
            vm = new EventoViewModelMem();

            // Definir a fonte de dados da lista
            lvEvento.ItemsSource = vm.Lista;

            // Criar registros de teste
            var e1 = new Evento()
            {
                Nome = "Aniversário Reginaldo",
                Local = "Minha casa",
                Data = new DateTime(2018,08,25),
                HoraInicio = "23:00",
                HoraTermino = "4:00",
                Anotacoes = "Comprar bebidas",
                Status = "Ocupado"

            };

            // adicionar item na lista
            vm.Salvar(e1);
        } */

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lvEvento.ItemsSource = await App.Database.GetEventosAsync();
        }

    }
}
