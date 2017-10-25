using Xamarin.Forms;

namespace Contatos
{
    public partial class App : Application
    {
     

        public App()
        {
            InitializeComponent();

            // Seta a MainPage para abrir o EventoListaPage XAML
            //MainPage = new Contatos.Pages.PessoaListaPage();
            MainPage = new NavigationPage(new Contatos.Pages.PessoaListaPage()) { BarBackgroundColor = Color.FromHex("#b712a4"), BarTextColor = Color.FromHex("#000000"), BackgroundColor = Color.FromHex("#04cea9")};
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
