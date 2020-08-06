using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for RegistrationDoctorView.xaml
    /// </summary>
    public partial class RegistrationDoctorView : Window
    {
        public RegistrationDoctorView()
        {
            InitializeComponent();
            this.DataContext = new RegistrationDoctorViewModel(this);
        }
    }
}