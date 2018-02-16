

namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {


        #region Attributes
        private string password;
        private bool isRunnig;
        private bool isEnabled;

        #endregion


        #region Properties
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                SetValue(ref this.password, value);
            }
        }

        public bool IsRunnig
        {
            get
            {
                return this.isRunnig;
            }
            set
            {
                SetValue(ref this.isRunnig, value);
            }
        }

        public bool IsRemembered { get; set; }

        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                SetValue(ref this.isEnabled, value);
            }
        }

        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;

        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Email!",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password!",
                    "Accept");
                return;
            }

            this.IsRunnig = true;
            this.IsEnabled = false;

            if (this.Email != "tenkan.af@gmail.com" || this.Password != "1234")
            {
                this.IsRunnig = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password incorrect.",
                    "Accept");
                this.Password = string.Empty;
                return;

            }

            this.IsRunnig = false;
            this.IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert(
                "Ok",
                "Listo!",
                "Accept");
        }
        #endregion
    }
}
