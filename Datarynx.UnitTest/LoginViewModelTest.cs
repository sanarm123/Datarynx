using Datarynx.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datarynx.UnitTest
{

   public class LoginViewModelTest
    {
        private LoginViewModel _loginViewModel;
        public LoginViewModelTest()
        {
            _loginViewModel = new LoginViewModel();
        }

        [Fact]
        public void LoadItemsCommand_Not_Null_Test()
        {

            Assert.NotNull(_loginViewModel.LoginCommand);
        }

    }
}
