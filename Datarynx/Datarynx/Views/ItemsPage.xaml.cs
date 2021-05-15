using Datarynx.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Datarynx.Views
{
    public partial class ItemsPage : ContentPage
    {
         ItemsViewModel _viewModel;


        public ItemsPage()
        {
            InitializeComponent();

          
            BindingContext = _viewModel =new ItemsViewModel();

        }

       

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Task.Delay(500);

            _viewModel.OnAppearing();
        }
    }
}