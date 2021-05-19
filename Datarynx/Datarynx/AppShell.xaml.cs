using Datarynx.ViewModels;
using Datarynx.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Datarynx
{

    [ExcludeFromCodeCoverage]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));

            OpenWebCommand = new Command(async () => await DelaMethod());

            BindingContext = this;
        }

        private static async Task DelaMethod()
        {
            await Task.Delay(100);
        }

        public ICommand OpenWebCommand { get; }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void HeaderContentView_Clicked(object sender, EventArgs e)
        {
            //
        }
    }
}
