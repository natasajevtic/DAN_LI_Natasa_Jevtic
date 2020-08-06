using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        MainWindow main;
        Users users = new Users();
        public vwPatient Patient { get; set; }
        public vwDoctor Doctor { get; set; }

        private string username;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand logIn;

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(LogInExecute, CanLogInExecute);
                }
                return logIn;
            }
        }

        private ICommand signUp;

        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }

        public MainWindowViewModel(MainWindow main)
        {
            this.main = main;
        }
        /// <summary>
        /// This method checks if username and password valid.
        /// </summary>
        /// <param name="password">User input for password.</param>
        public void LogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (users.FindPatient(Username, Password) != null)
            {
                Patient = users.FindPatient(Username, Password);
                PatientView patientView = new PatientView(Patient);
                patientView.ShowDialog();
            }
            else if (users.FindDoctor(Username, Password) != null)
            {
                Doctor = users.FindDoctor(Username, Password);
                DoctorView doctorView = new DoctorView(Doctor);
                doctorView.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wrong username or password. Please, try again.", "Notification");
            }
        }
        /// <summary>
        /// This method ensures that the login can only be executed when the login fields are not empty.
        /// </summary>
        /// <param name="password">User input for password.</param>
        /// <returns>True if login can execute, false if not.</returns>
        public bool CanLogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanSignUpExecute()
        {
            return true;
        }

        public void SignUpExecute()
        {
            RegistrationView registrationView = new RegistrationView();
            registrationView.ShowDialog();
        }
    }
}