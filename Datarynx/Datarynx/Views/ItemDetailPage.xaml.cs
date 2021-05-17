using Datarynx.ViewModels;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
namespace Datarynx.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<ItemDetailViewModel>();
        }
    }
}