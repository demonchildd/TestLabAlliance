using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfClient.Model;
using WpfClient.Services;
using WpfClient.Services.Commands;
using WpfClient.Services.Interfaces;

namespace WpfClient.ViewModel
{
    public class UsersPageVM : BaseVM
    {

        private readonly IUserService _userService;

        public UsersPageVM()
        {
            _userService = new UserService();
            Users = new List<User>();
        }

        private List<User> _users;

        public List<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private string _currentError;
        public string CurrentError
        {
            get => _currentError;
            set
            {
                _currentError = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand GetUsersCommand;
        public ICommand GetUsers
        {
            get
            {
                if (GetUsersCommand == null)
                    GetUsersCommand = new RelayCommand(async _ => await GetUsersExecuted());

                return GetUsersCommand;
            }
        }
        private async Task GetUsersExecuted()
        {


            try
            {
                var users = await _userService.GetUsersAsync();
                if (users != null)
                {
                    var buff = new List<User>();
                    foreach (var user in users)
                    {
                        buff.Add(user);
                    }
                    Users = buff;
                    CurrentError = string.Empty;
                }
                else
                {
                    Users.Clear();
                    CurrentError = "Не удалось получить данные пользователей.";
                }
            }
            catch (Exception ex)
            {
                Users.Clear();
                CurrentError = $"Ошибка: {ex.Message}";
            }





        }
    }
}
