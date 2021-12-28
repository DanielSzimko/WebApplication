using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebApplication_Doctor.DataProviders;
using WebApplication_Server.Models;

namespace WebApplication_Doctor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdatePatientListBox();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs args)
        {

            var selectedPatient = PatientsListBox.SelectedItem as Patient;

            if(selectedPatient != null)
            {
                var window = new PatientWindow(selectedPatient);

                if (window.ShowDialog() ?? false)
                {
                    UpdatePatientListBox();
                }
            }

        }

        private void UpdatePatientListBox()
        {
            var patient = PatientDataProvider.GetPatients().ToList();
            PatientsListBox.ItemsSource = patient;
        }
    }
}

