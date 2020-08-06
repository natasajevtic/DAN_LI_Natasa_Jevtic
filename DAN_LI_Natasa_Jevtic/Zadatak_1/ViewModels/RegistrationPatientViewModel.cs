using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class RegistrationPatientViewModel : BaseViewModel
    {
        RegistrationPatientView registrationPatientView;
        Patients patients = new Patients();

        private vwPatient patient;

        public vwPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
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

        public RegistrationPatientViewModel(RegistrationPatientView registrationPatientView)
        {
            this.registrationPatientView = registrationPatientView;
            Patient = new vwPatient();
        }

        public void RegisterExecute()
        {
            if (String.IsNullOrEmpty(Patient.Name) || String.IsNullOrEmpty(Patient.Surname) || String.IsNullOrEmpty(Patient.JMBG) ||
               String.IsNullOrEmpty(Patient.Username) || String.IsNullOrEmpty(Patient.Password) || String.IsNullOrEmpty(Patient.HealthInsuranceCardNumber))
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
                        bool isCreated = patients.AddPatient(Patient);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Patient is registered.", "Notification", MessageBoxButton.OK);
                            registrationPatientView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Patient cannot be registered.", "Notification", MessageBoxButton.OK);
                            registrationPatientView.Close();
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
                    registrationPatientView.Close();
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