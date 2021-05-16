using Datarynx.ViewModels;
using Datarynx.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace Datarynx
{
    [ExcludeFromCodeCoverage]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            FlyoutIcon.AutomationId = "FlyoutIconAutoId";
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }
      

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
