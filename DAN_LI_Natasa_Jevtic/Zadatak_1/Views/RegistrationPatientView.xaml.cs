using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for RegistrationPatientView.xaml
    /// </summary>
    public partial class RegistrationPatientView : Window
    {
        public RegistrationPatientView()
        {
            InitializeComponent();
            this.DataContext = new RegistrationPatientViewModel(this);
        }
    }
}