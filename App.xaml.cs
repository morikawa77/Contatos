﻿using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Contatos.Data;
using Contatos.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Contatos
{
    public partial class App : Application
    {
        // Atributos Globais
        // const atributo somente de leitura
        public const string nomeApp = "Agenda"; 
        // Configuração da página mestre detalhe ativa
        public static MasterDetailPage PaginaMestreDetalhe { get; set; }

        static ContatosDB database;

        //Métodos de navegação da aplicação
        public static async Task NavegacaoPagina(Page pagina)
        {
            // Define o título
            pagina.Title = nomeApp;
            // Fechar a página de menu
            App.PaginaMestreDetalhe.IsPresented = false;
            // Carrega a nova página a partir do início (página mestre detalhe)
            await PaginaMestreDetalhe.Detail.Navigation.PushAsync(pagina, true);
        }

        public static async Task NavegacaoPaginaAnteriorAsync()
        {
            // Fechar a página de menu
            App.PaginaMestreDetalhe.IsPresented = false;
            // Voltar para a página anterior
            await PaginaMestreDetalhe.Detail.Navigation.PopAsync(true);
        }

        public static async Task NavegacaoPaginaInicialAsync()
        {
            // Fechar a página de menu
            App.PaginaMestreDetalhe.IsPresented = false;
            await PaginaMestreDetalhe.Detail.Navigation.PopToRootAsync();
        }

        // Dialogos

        // Exibe uma mensagem de alerta em tela
        public static async Task DialogoAlerta(
            string titulo,
            string mensagem,
            string cancelar)
        {
            await App.Current.MainPage.DisplayAlert(titulo, mensagem, cancelar);
        }

        // Exibe uma mensagem de alerta em tela e volta o resultado
        // Confirmar = true
        // Cancelar = false
        public static async Task<bool> DialogoAlerta(
            string titulo,
            string mensagem,
            string confirmar,
            string cancelar)
        {
            return await App.Current.MainPage.DisplayAlert(titulo, mensagem, confirmar, cancelar);
        }

        // Exibe um menu de opções 
        // Ao escolher volta a opção (texto) escolhido
        public static async Task<string> DialogoOpcoes(
            string titulo,
            string cancela,
            params string[] opcoes)
        {
            return await App.Current.MainPage.DisplayActionSheet(titulo, cancela, null, opcoes);
        }

        public App()
        {
            InitializeComponent();

            // Seta a MainPage para abrir o EventoListaPage XAML
            //MainPage = new Contatos.Pages.PessoaListaPage();
            //MainPage = new NavigationPage(new Contatos.Pages.PessoaListaPage()) { BarBackgroundColor = Color.FromHex("#b712a4"), BarTextColor = Color.FromHex("#000000"), BackgroundColor = Color.FromHex("#04cea9")};
            MainPage = new MasterPage();
        }

        public static ContatosDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new ContatosDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("contatos.db3"));
                }
                return database;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


    }
}
