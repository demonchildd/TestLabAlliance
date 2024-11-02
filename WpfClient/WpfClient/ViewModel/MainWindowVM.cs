using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfClient.Model;
using WpfClient.Services.Commands;
using WpfClient.View.Frames;

namespace WpfClient.ViewModel
{
    public class MainWindowVM : BaseVM
    {



        public MainWindowVM()
        {
            CurrentContent = new RegistrationPage();
           
        }
        private Page _currentContent;

        
        public Page CurrentContent
        {
            get => _currentContent;
            set
            {
                _currentContent = value;
                OnPropertyChanged();
            }
        }

        public void ChangeFrame(string action)
        {

            switch (action)
            {
                case "Registration":
                    CurrentContent = new RegistrationPage();
                    break;
                case "Login":
                    CurrentContent = new LoginPage();
                    break;
                case "Users":
                    CurrentContent = new UsersPage();
                    break;
                

            }
        }



        private RelayCommand SetFrameCommand;
        public ICommand SetFrame
        {
            get
            {
                if (SetFrameCommand == null)
                    SetFrameCommand = new RelayCommand(SetFrameExecuted);

                return SetFrameCommand;
            }
        }
        private void SetFrameExecuted(object obj)
        {
            
            ChangeFrame((string)obj);
            
            

        }

    }
}
