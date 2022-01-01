using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebApplication_Doctor.DataProviders;
using WebApplication_Server.Models;

namespace WebApplication_Doctor
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        private readonly Patient _Patient;
        public PatientWindow(Patient patient)
        {
            InitializeComponent();

            if (patient != null)
            {
                _Patient = patient;

                NameTextBox.Text = _Patient.Name;
                AddressTextBox.Text = _Patient.Address;
                TAJNumberTextBox.Text = _Patient.TAJNumber;
                ComplaintTextBox.Text = _Patient.Complaint;
                DiagnosisTextBox.Text = _Patient.Diagnosis;

                UpdateButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePatient())
            {
                _Patient.Name = NameTextBox.Text;
                _Patient.Address = AddressTextBox.Text;
                _Patient.TAJNumber = TAJNumberTextBox.Text;
                _Patient.Complaint = ComplaintTextBox.Text;
                _Patient.Diagnosis = DiagnosisTextBox.Text;
                
                PatientDataProvider.UpdatePatient(_Patient);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                PatientDataProvider.DeletePatient(_Patient.Id);

                DialogResult = true;
                Close();
            }
        }

        private bool ValidatePatient()
        {

            if (NameTextBoxValidation() && TAJNumberTextBoxValidation() && ComplaintsTextBoxValidation())
            {
                return true;
            }

            return false;
        }

        // NAMETEXTBOX VALIDATION

        private bool NameTextBoxValidation()
        {

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty.");
                return false;
            }

            if (NameTextBox.Text.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Name should not contain special characters.");
                return false;
            }
            return true;
        }

        // TAJNUMBERTEXTBOX VALIDATION 

        private bool TAJNumberTextBoxValidation()
        {

            Regex rg = new Regex("([0-9]{3} [0-9]{3} [0-9]{3}$)");

            if (!rg.IsMatch(TAJNumberTextBox.Text))
            {
                MessageBox.Show("TAJ number should be like: 123 456 789");
                return false;
            }

            return true;
        }

        // COMPLAINTSTEXTBOX VALIDATION

        private bool ComplaintsTextBoxValidation()
        {

            if (string.IsNullOrEmpty(ComplaintTextBox.Text))
            {
                MessageBox.Show("Complaints should not be empty.");
                return false;
            }

            return true;
        }

    }
}
