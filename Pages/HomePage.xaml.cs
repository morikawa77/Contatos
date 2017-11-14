using System;
using System.Collections.Generic;
using Contatos.Pages;
using Xamarin.Forms;

namespace Contatos.Pages
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();

            var tab1 = new EventoListaPage() { Title = "Eventos", Icon = "eventos.png" };
            var tab2 = new PessoaListaPage() { Title = "Contato", Icon = "pessoas.png" };

            this.Children.Add(tab1);
            this.Children.Add(tab2);
        }
    }
}
