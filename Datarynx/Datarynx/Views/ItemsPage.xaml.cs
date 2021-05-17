using Datarynx.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
namespace Datarynx.Views
{
    [ExcludeFromCodeCoverage]
    public partial class ItemsPage : ContentPage
    {
     
        public ItemsPage()
        {
            InitializeComponent();
             BindingContext = Startup.ServiceProvider.GetService<ItemsViewModel>();

        }
              

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((ItemsViewModel)BindingContext).OnAppearing();

        }
    }
}