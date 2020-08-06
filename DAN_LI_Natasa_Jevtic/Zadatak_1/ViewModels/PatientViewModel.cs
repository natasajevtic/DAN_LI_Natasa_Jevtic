using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class PatientViewModel : BaseViewModel
    {
        PatientView patientView;

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

        public PatientViewModel(PatientView patientView, vwPatient patient)
        {
            this.patientView = patientView;
            Patient = patient;
        }
    }
}