using Datarynx.Models;
using FluentValidation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.AttributeValidation.Attributes;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{

   
    public class AboutViewModel : BaseViewModel
    {
        private string _input;

      
        public string Input
        {
            get => _input;
            set
            {
                SetProperty(ref _input, value);
               
            }
        }

        private readonly UserValidator _validator;
        public AboutViewModel()
        {
            Title = "About";
            _validator = new UserValidator();
            OpenWebCommand = new Command(async () =>
                {

                    var tt = new User()
                    {
                        FirstName = "Ss",
                        LastName = "Ae"
                    };

                    var result = _validator.Validate(tt);


                    if (result.IsValid)
                    {
                        // DisplayAlert("Cadastro", "Cadastro Validado com Sucesso", "Ok");
                    }
                    else
                    {
                        var erros = "";
                        foreach (var failure in result.Errors)
                        {
                            erros += $",{failure.ErrorMessage}";
                        }


                    }

                    await Task.Delay(100);


                });

           
            
        }

        public ICommand OpenWebCommand { get; }
    }
}