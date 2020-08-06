using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class DoctorViewModel : BaseViewModel
    {
        DoctorView doctorView;

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

        public DoctorViewModel(DoctorView doctorView, vwDoctor doctor)
        {
            this.doctorView = doctorView;
            Doctor = doctor;
        }
    }
}