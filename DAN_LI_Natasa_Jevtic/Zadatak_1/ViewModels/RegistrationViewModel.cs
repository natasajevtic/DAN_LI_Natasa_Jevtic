using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class RegistrationViewModel : BaseViewModel
    {
        RegistrationView registrationView;

        private bool isCheckedPatient;

        public bool IsCheckedPatient
        {
            get
            {
                return isCheckedPatient;
            }
            set
            {
                isCheckedPatient = value;
                OnPropertyChanged("IsCheckedPatient");
            }
        }

        private bool isCheckedDoctor;

        public bool IsCheckedDoctor
        {
            get
            {
                return isCheckedDoctor;
            }
            set
            {
                isCheckedDoctor = value;
                OnPropertyChanged("IsCheckedDoctor");
            }
        }

        private ICommand next;

        public ICommand Next
        {
            get
            {
                if (next == null)
                {
                    next = new RelayCommand(param => NextExecute(), param => CanNextExecute());
                }
                return next;
            }
        }

        public RegistrationViewModel(RegistrationView registrationView)
        {
            this.registrationView = registrationView;
        }

        public bool CanNextExecute()
        {
            if (IsCheckedPatient == true || IsCheckedDoctor == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NextExecute()
        {
            if (IsCheckedDoctor)
            {
                RegistrationDoctorView doctorView = new RegistrationDoctorView();
                doctorView.ShowDialog();
                //closing after registration
                registrationView.Close();
            }
            else
            {
                RegistrationPatientView patientView = new RegistrationPatientView();
                patientView.ShowDialog();
                //closing after registration
                registrationView.Close();
            }
        }
    }
}