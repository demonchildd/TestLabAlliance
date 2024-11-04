using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfClient.Services;
using WpfClient.Services.Commands;
using WpfClient.Services.Interfaces;

namespace WpfClient.ViewModel
{
    public class LoginPageVM : BaseVM
    {
        private readonly IUserService _userService;

        public LoginPageVM()
        {
            _userService = new UserService();
        }

        private string _currentLogin;


        public string CurrentLogin
        {
            get => _currentLogin;
            set
            {
                _currentLogin = value;
                OnPropertyChanged();
            }
        }

        private string _currentPassword;


        public string CurrentPassword
        {
            get => _currentPassword;
            set
            {
                _currentPassword = value;
                OnPropertyChanged();
            }
        }

        private string _currentInfo;


        public string CurrentInfo
        {
            get => _currentInfo;
            set
            {
                _currentInfo = value;
                OnPropertyChanged();
            }
        }


        public void SetInfo(string info)
        {
            CurrentInfo = info;
        }

        private RelayCommand RegistrationCommand;
        public ICommand Registration
        {
            get
            {
                if (RegistrationCommand == null)
                    RegistrationCommand = new RelayCommand(async _ => await RegistrationExecuted());

                return RegistrationCommand;
            }
        }
        private async Task RegistrationExecuted()
        {
            if (CurrentPassword == "" || CurrentPassword == null || CurrentLogin == "" || CurrentLogin == null)
            {
                SetInfo("Заполните поля");

            }
            else
            {
                MessageBox.Show(CurrentLogin);
                SetInfo("");
            }



        }


        private RelayCommand CheckCommand;
        public ICommand Check
        {
            get
            {
                if (CheckCommand == null)
                    CheckCommand = new RelayCommand(CheckExecuted);

                return CheckCommand;
            }
        }

        private void CheckExecuted(object obj)
        {
            SetInfo("");
        }

    }
}
