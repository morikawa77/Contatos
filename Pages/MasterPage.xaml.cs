using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Contatos.Pages
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();

            // Configuração da página Mestre Detalhe
            //  Página de navegação (Master)
            this.Master = new MenuPage(){ Title = "Menu" };
            // Página de detalhes
            this.Detail = new NavigationPage(new HomePage() { Title = App.nomeApp });
            // Seta o comportamento de exibição para o tipo popOver (abre e fecha) do menu
            this.MasterBehavior = MasterBehavior.Popover;
            // Define mestre detalhe ativa
            App.PaginaMestreDetalhe = this;
        }
    }
}
