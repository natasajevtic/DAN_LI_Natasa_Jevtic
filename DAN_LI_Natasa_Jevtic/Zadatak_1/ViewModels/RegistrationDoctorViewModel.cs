using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class RegistrationDoctorViewModel : BaseViewModel
    {
        RegistrationDoctorView registrationDoctorView;
        Doctors doctors = new Doctors();

        private vwDoctor doctor;

        public vwDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand(param => RegisterExecute(), param => CanRegisterExecute());
                }
                return register;
            }
        }

        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        public RegistrationDoctorViewModel(RegistrationDoctorView registrationDoctorView)
        {
            this.registrationDoctorView = registrationDoctorView;
            Doctor = new vwDoctor();
        }

        public void RegisterExecute()
        {
            if (String.IsNullOrEmpty(Doctor.Name) || String.IsNullOrEmpty(Doctor.Surname) || String.IsNullOrEmpty(Doctor.JMBG) ||
               String.IsNullOrEmpty(Doctor.Username) || String.IsNullOrEmpty(Doctor.Password) || String.IsNullOrEmpty(Doctor.BankAccountNumber))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to register?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = doctors.AddDoctor(Doctor);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Doctor is registered.", "Notification", MessageBoxButton.OK);
                            registrationDoctorView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Doctor cannot be registered.", "Notification", MessageBoxButton.OK);
                            registrationDoctorView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanRegisterExecute()
        {
            return true;
        }

        public void CancelExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel registration?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    registrationDoctorView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelExecute()
        {
            return true;
        }
    }
}